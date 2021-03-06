﻿namespace Emergency_Skeleton.Core
{
    using Emergency_Skeleton.Interfaces.Collections;
    using Emergency_Skeleton.Interfaces.Core;

    public class EmergencyManagementSystem : IManagementSystem
    {
        private readonly IEmergencyRegister emergencyRegister;

        public EmergencyManagementSystem(IEmergencyRegister emergencyRegister)
        {
            this.emergencyRegister = emergencyRegister;
        }

        public string RegisterPropertyEmergency()
        {
            return null;
        }

        public string RegisterHealthEmergency()
        {
            return null;
        }

        public string RegisterOrderEmergency()
        {
            return null;
        }

        public string RegisterFireServiceCenter()
        {
            return null;
        }

        public string RegisterMedicalServiceCenter()
        {
            return null;
        }

        public string RegisterPoliceServiceCenter()
        {
            return null;
        }

        public string ProcessEmergencies()
        {
            return null;
        }

        public string EmergencyReport()
        {
            return null;
        }
    }
}
