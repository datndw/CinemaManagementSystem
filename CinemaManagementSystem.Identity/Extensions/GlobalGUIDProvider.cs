namespace CinemaManagementSystem.Identity.Extensions
{
    public static class GlobalGUIDProvider
    {
        private static List<Guid> Identities = new();
        public static Guid Request(int index)
        {
            if (index < 0) return Guid.Empty;

            if (index < Identities.Count) return Identities[index];
            else {
                for (int i = 0; i < index - Identities.Count + 1; i++)
                {
                    Identities.Add(Guid.NewGuid());
                }
                return Identities[index];
            }
        }
    }
}
