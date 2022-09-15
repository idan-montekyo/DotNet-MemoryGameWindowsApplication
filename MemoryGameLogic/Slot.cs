using System.Collections.Generic;

namespace MemoryGameLogic
{
    public class Slot
    {
        private readonly char r_Value;
        private readonly string r_ImageLocation;
        private bool m_Hidden;
        
        public Slot(char i_Value)
        {
            this.r_Value = i_Value;
            Images.GetImageLocationCorrespondingToSlotValue(i_Value, out this.r_ImageLocation);
            this.m_Hidden = true;
        }

        public char Value
        {
            get { return this.r_Value; }
        }

        public bool IsHidden
        {
            get { return this.m_Hidden; }
            set { this.m_Hidden = value; }
        }

        public string ImageLocation
        {
            get { return r_ImageLocation; }
        }
    }
}
