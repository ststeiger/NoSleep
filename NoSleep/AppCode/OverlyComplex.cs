
#if false


namespace NoSleep
{


    class OverlyComplexSolution
    {

        protected WindowsInput.InputSimulator m_wis;
        protected WindowsInput.MouseSimulator m_ms;


        public OverlyComplexSolution()
        {
            m_wis = new WindowsInput.InputSimulator();
            m_ms = new WindowsInput.MouseSimulator(m_wis);
        }

        public void PretendInput()
        {
            m_ms.MoveMouseBy(1, 0);
            m_ms.MoveMouseBy(-1, 0);
        } // End Sub PretendInput


        public void ContinuousInputSimulation()
        {
            while (true)
            {
                PretendInput();
                System.Threading.Thread.Sleep(30 * 1000);
            } // Whend
        } // End Sub ContinuousInputSimulation


    } // End Class OverlyComplexSolution 


} // End Namespace NoSleep

#endif
