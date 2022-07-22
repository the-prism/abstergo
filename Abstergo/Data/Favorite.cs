namespace Abstergo.Data
{
    public class Favorite
    {
        public int Id { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Name { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Url { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool IsFolder { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }


        public Favorite Parent { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public List<Favorite> FolderContents => throw new NotImplementedException();
    }
}
