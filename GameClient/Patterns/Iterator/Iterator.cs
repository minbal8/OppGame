namespace GameClient
{
    interface Iterator<T>
    {
        bool HasNext();
        T Next();
        T First();

    }
}
