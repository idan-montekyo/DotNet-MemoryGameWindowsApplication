namespace Ex02
{
    public class Slot
    {
        private char m_Value;
        private bool m_Hidden;
        // TODO: add string or resource m_Image

        public Slot(char i_Value)
        {
            this.m_Value = i_Value;
            this.m_Hidden = true;
        }

        public char Value
        {
            get
            {
                return this.m_Value;
            }
        }

        public bool IsHidden
        {
            get
            {
                return this.m_Hidden;
            }
            set
            {
                this.m_Hidden = value;
            }
        }
    }
}
