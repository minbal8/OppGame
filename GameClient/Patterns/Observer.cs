namespace GameClient
{
    public abstract class Observer
    {
        protected Subject _subject { get; set; }


        public abstract void Update();
        public void SetSubject(Subject subject)
        {
            _subject = subject;
        }
    }
}
