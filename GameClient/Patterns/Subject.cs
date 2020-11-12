using System.Collections.Generic;

namespace GameClient
{
    public abstract class Subject
    {
        private List<Observer> observers = new List<Observer>();
        public void Attach(Observer o)
        {
            observers.Add(o);
            o.SetSubject(this);
        }

        public void Dettach(Observer o)
        {
            observers.Remove(o);
        }

        public abstract int GetState();

        public void Notify()
        {
            foreach (var item in observers)
            {
                item.Update();
            }
        }

    }
}
