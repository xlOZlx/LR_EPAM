﻿using Aircompany.Models;

namespace Aircompany.Planes
{
    public class MilitaryPlane : Plane
    {
        private MilitaryType militaryType;

        public MilitaryPlane(string model, int maxSpeed, int maxFlightDistance, int maxLoadCapacity, MilitaryType militaryType)
            : base(model, maxSpeed, maxFlightDistance, maxLoadCapacity)
        {
            this.militaryType = militaryType;
        }

        public override bool Equals(object objectToCompare)
        {
            return (objectToCompare as MilitaryPlane) != null &&
                   base.Equals(objectToCompare) &&
                   militaryType == (objectToCompare as MilitaryPlane).militaryType;
        }

        public override int GetHashCode()
        {
            int coefficient = -1521134295;
            return ((1701194404 * coefficient) + base.GetHashCode()) * -1521134295 + militaryType.GetHashCode();
        }

        public MilitaryType GetPlaneType()
        {
            return militaryType;
        }

        public override string ToString()
        {
            return base.ToString().Replace("}", ", type=" + militaryType + '}');
        }        
    }
}
