namespace CS_OOP_Advanced_Exam_Prep_July_2016.Core.Controllers
{
    using CS_OOP_Advanced_Exam_Prep_July_2016.Attributes;

    [Controller]
    public class ProductsController
    {
        [RequestMapping("/product/{size}/{name}/{type}", RequestMethod.ADD)]
        public string AddProduct(
            [UriParameter("size")] int size, 
            [UriParameter("name")] string name, 
            [UriParameter("type")] string type)
        {

            return "AddProduct";
        }
    }
}
