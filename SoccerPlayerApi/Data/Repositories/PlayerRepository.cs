using SoccerPlayerApi.Data.Intefaces;

namespace SoccerPlayerApi.Data.Repositories
{

    public class PlayerRepository : IPlayerRepository
    {
        private readonly SoccerPlayersContext _Context;

        public PlayerRepository(SoccerPlayersContext dbContext)
        {

            _Context = dbContext;
        }

        public async Task<Player> CreatePlayer(Player player)
        {
          var result =   _Context.Players.Add(player);
             await _Context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<bool> DeletePlayer(int playerId)
        {
            
            var player = await _Context.Players.Where(x => x.PlayerId == playerId).FirstOrDefaultAsync();

            var result=  _Context.Players.Remove(player);
                await _Context.SaveChangesAsync();
            return result != null ? true : false;


        }
        

        public async Task<int> EditPlayer(Player player)
        {
            var playerToEdit = await _Context.Players.Where(x => x.PlayerId == player.PlayerId).FirstOrDefaultAsync();
            playerToEdit.PlayerName = player.PlayerName;
            playerToEdit.JeresyNumber = player.JeresyNumber;
            await _Context.SaveChangesAsync();
            return player.PlayerId;
        }

        public async Task<List<Player>> GetPlayers()
        {
            var result = await _Context.Players.ToListAsync();
            return result;
        }     
    }
}
