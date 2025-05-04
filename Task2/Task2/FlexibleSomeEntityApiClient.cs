namespace Task2
{
    public class FlexibleSomeEntityApiClient
    {
        private SomeEntityApiClient _baseClient;

        public FlexibleSomeEntityApiClient(SomeEntityApiClient baseClient)
        {
            _baseClient = baseClient;
        }

        public List<SomeEntity> GetByName(string name)
        {
            return _baseClient.GetMany().FindAll(e => e.Name == name);
        }

        public List<SomeEntity> GetByStatus(string status)
        {
            return _baseClient.GetMany().FindAll(e => e.Status == status);
        }

        public List<SomeEntity> GetSortedByName()
        {
            var list = _baseClient.GetMany();
            list.Sort((a, b) => a.Name.CompareTo(b.Name));
            return list;
        }
    }
}
