namespace CS_OOP_Advanced_Exam_Prep_July_2016.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using CS_OOP_Advanced_Exam_Prep_July_2016.Attributes;
    using CS_OOP_Advanced_Exam_Prep_July_2016.Interfaces.Core;

    public class AttributeParser : IParser
    {
        /// <summary>
        /// Association of Request Method => URI => Controller.Action()
        /// e.g. "GET" => "/users/6" => {"UsersController", "Get(id)"}
        /// </summary>
        private Dictionary<RequestMethod, Dictionary<string, ControllerActionPair>> controllers;

        /**
        * A component is any bean that can be injected by any resolver
        * The association kept here is:
        *     "Abstraction" => "Implementation"
        */
        private Dictionary<Type, Type> components;

        public AttributeParser()
        {
            this.controllers = new Dictionary<RequestMethod, Dictionary<string, ControllerActionPair>>();
            this.components = new Dictionary<Type, Type>();
        }

        public Dictionary<RequestMethod, Dictionary<string, ControllerActionPair>> Controllers
        {
            get
            {
                return controllers;
            }
        }

        public Dictionary<Type, Type> Components
        {
            get
            {
                return components;
            }
        }

        public void Parse()
        {
            Type[] allTypesInCurrentExecutingAssembly = Assembly.GetExecutingAssembly().GetTypes();
            Type[] controllerTypes =
                allTypesInCurrentExecutingAssembly
                    .Where(t => t.GetCustomAttributes<ControllerAttribute>().Any())
                    .ToArray();

            foreach (Type controllerType in controllerTypes)
            {
                var currentTypeMethods = controllerType.GetMethods(BindingFlags.Instance | BindingFlags.Public);

                foreach (var currentMethod in currentTypeMethods)
                {
                    var isCurrentMethodForRequestMapping = currentMethod
                        .GetCustomAttributes()
                        .Any(x => x.GetType() == typeof(RequestMappingAttribute));

                    if (isCurrentMethodForRequestMapping)
                    {
                        RequestMappingAttribute methodRequestMappingAttribute =
                            currentMethod.GetCustomAttribute<RequestMappingAttribute>();

                        RequestMethod requestMethod = methodRequestMappingAttribute.Method;
                        string mapping = methodRequestMappingAttribute.Value;
                        List<string> mappingTokens = mapping.Split(new[] { '/' }, StringSplitOptions.RemoveEmptyEntries).ToList();

                        Dictionary<int, Type> argumentsMapping = new Dictionary<int, Type>();

                        for (int i = 0; i < mappingTokens.Count; i++)
                        {
                            var isTokenRequestParameter = mappingTokens[i].StartsWith("{") && mappingTokens[i].EndsWith("}");
                            if (isTokenRequestParameter)
                            {
                                foreach (ParameterInfo parameterInfo in currentMethod.GetParameters())
                                {
                                    int numberOfUriParameterAttributes = parameterInfo
                                        .GetCustomAttributes()
                                        .Count(x => x.GetType() == typeof(UriParameterAttribute));
                                    if (numberOfUriParameterAttributes == 0)
                                    {
                                        continue;
                                    }

                                    UriParameterAttribute uriParameter =
                                        parameterInfo.GetCustomAttribute<UriParameterAttribute>();

                                    bool isTargetMappingToken = mappingTokens[i].Equals("{" + uriParameter.Value + "}");
                                    if (isTargetMappingToken)
                                    {
                                        argumentsMapping.Add(i, parameterInfo.ParameterType);

                                        string updatedMapping = mapping
                                            .Replace(mappingTokens[i].ToString(), parameterInfo.ParameterType == typeof(string) ? "\\w+" : "\\d+");
                                        mapping = updatedMapping;
                                        break;
                                    }
                                }
                            }
                        }

                        Object controllerInstance = Activator.CreateInstance(controllerType);

                        ControllerActionPair controllerActionPair = new ControllerActionPair(controllerInstance, currentMethod, argumentsMapping);

                        if (!this.Controllers.ContainsKey(requestMethod))
                        {
                            this.Controllers.Add(requestMethod, new Dictionary<string, ControllerActionPair>());
                        }

                        this.Controllers[requestMethod].Add(mapping, controllerActionPair);
                    }
                }
            }

            Type[] componentTypes =
                allTypesInCurrentExecutingAssembly
                    .Where(t => t.GetCustomAttributes<ComponentAttribute>().Any())
                    .ToArray();
            foreach (var componentType in componentTypes)
            {
                foreach (Type parent in componentType.GetInterfaces())
                {
                    this.Components.Add(parent, componentType);
                }
            }

            foreach (ControllerActionPair controllerActionPair in this.Controllers.Values.SelectMany(x => x.Values))
            {
                this.ResolveDependencies(controllerActionPair.Controller);
            }
        }

        public T Resolve<T>()
        {
            if (!this.components.ContainsKey(typeof(T)))
            {
                throw new InvalidOperationException("Cannot map dependency of type "
                    + typeof(T).Name
                    + ". It is not annotated with @Component ");
            }

            T result = Activator.CreateInstance<T>();

            this.ResolveDependencies(result);

            return result;
        }

        private void ResolveDependencies(object controller)
        {
            FieldInfo[] currentDependencies =
                controller.GetType()
                    .GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                    .Where(x => x.GetCustomAttributes().Any(attr => attr.GetType() == typeof(InjectAttribute)))
                    .ToArray();

            foreach (FieldInfo currentDependency in currentDependencies)
            {
                Type currentDependencySource = currentDependency.GetType();

                if (!this.Components.ContainsKey(currentDependencySource))
                {
                    throw new InvalidOperationException("Cannot map dependency of type "
                                                        + currentDependencySource.Name +
                                                        ". It is not annotated with @Component ");

                }

                Type currentDependencyTarget = this.Components[currentDependencySource];

                object currentDependencyInstance = Activator.CreateInstance(currentDependencyTarget);

                currentDependency.SetValue(controller, currentDependencyInstance);

                // Possible bug
                this.ResolveDependencies(currentDependencyInstance);
            }
        }
    }


}
