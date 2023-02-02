namespace SoccerPlayerApi.Data.Intefaces
{
    public interface IPlayerRepository
    {
        Task<List<Player>> GetPlayers();
        Task<int> EditPlayer(Player player);
        Task<Player> CreatePlayer(Player player);
        Task<bool> DeletePlayer(int playerId);
    }
}
