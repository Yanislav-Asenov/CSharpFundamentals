namespace Emergency_Skeleton.Collections
{
    using Emergency_Skeleton.Interfaces.Collections;
    using Emergency_Skeleton.Interfaces.Models.Emergencies;
    using Emergency_Skeleton.Models.Emergencies;
    using System;

    public class EmergencyRegister : IEmergencyRegister
    {

        private const int INITIAL_SIZE = 16;

        private IEmergency[] emergencyQueue;

        private int currentSize;

        private int nextIndex;

        public EmergencyRegister()
        {
            this.emergencyQueue = new BaseEmergency[INITIAL_SIZE];
            this.currentSize = 0;
            this.nextIndex = 0;
        }

        private void IncrementNextIndex()
        {
            this.nextIndex++;
        }

        private void DecrementNextIndex()
        {
            this.nextIndex--;
        }

        private void IncrementCurrentSize()
        {
            this.currentSize++;
        }

        private void DecrementCurrentSize()
        {
            this.currentSize--;
        }

        private bool IsResizedNeeded()
        {
            return this.currentSize == this.emergencyQueue.Length;
        }

        private void Resize()
        {
            IEmergency[] newArray = new BaseEmergency[2 * this.currentSize];

            for (int i = 0; i < this.currentSize; i++)
            {
                newArray[i] = this.emergencyQueue[i];
            }

            this.emergencyQueue = newArray;
        }

        public void EnqueueEmergency(IEmergency emergency)
        {
            if (this.IsResizedNeeded())
            {
                this.Resize();
            }

            this.emergencyQueue[this.nextIndex] = emergency;
            this.IncrementNextIndex();

            this.IncrementCurrentSize();
        }

        public IEmergency DequeueEmergency()
        {
            if (this.IsEmpty())
            {
                throw new InvalidOperationException();
            }

            IEmergency removedElement = this.emergencyQueue[0];

            for (int i = 0; i < this.currentSize - 1; i++)
            {
                this.emergencyQueue[i] = this.emergencyQueue[i + 1];
            }

            this.DecrementNextIndex();
            this.DecrementCurrentSize();

            return removedElement;
        }

        public IEmergency PeekEmergency()
        {
            IEmergency peekedElement = this.emergencyQueue[0];
            return peekedElement;
        }

        public bool IsEmpty()
        {
            return this.currentSize == 0;
        }
    }
}
