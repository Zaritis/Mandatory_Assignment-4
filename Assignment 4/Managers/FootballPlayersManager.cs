using Assignment1;

namespace Assignment_4.FootballPlayersManager
{
    public class FootballPlayersManager
    {
        private static int _nextID = 1;
        public static List<FootBallPlayer> PlayerList = new List<FootBallPlayer>
        {
            new FootBallPlayer(_nextID,"Ronaldo",37,7),
            new FootBallPlayer(_nextID++,"Neuer",36, 1),
            new FootBallPlayer(_nextID++,"Benzema",34,9),
            new FootBallPlayer(_nextID++,"Kroos",28,8),
        };
    public List<FootBallPlayer> GetAll()
    {
            return new List<FootBallPlayer>(PlayerList);
    }
    public FootBallPlayer GetFootBallPlayerById(int id)
        {
            return PlayerList.Find(player => player.Id == id);
        }
    public FootBallPlayer Add(FootBallPlayer player)
        {
            player.Id = _nextID++;
            PlayerList.Add(player);
            return player;
        }
     public FootBallPlayer Delete(int id)
        {
            FootBallPlayer player = PlayerList.Find(player => player.Id == id);
            PlayerList.Remove(player);
            return player;
        }
     public FootBallPlayer Update(int id, FootBallPlayer update)
        {
            FootBallPlayer player = PlayerList.Find(player => player.Id == id);
            if (player == null) return null;
            player.Name = update.Name;
            player.ShirtNumber = update.ShirtNumber;
            return player;
        }
    }
}
