namespace MusicAPI.DbStuff.DbModels
{
    public class TrackModel : BaseModel
    {
        public string Author { get; set; }
        public string Name { get; set; }   
        public string Genre { get; set; }
        public DateTime DateOfPublication { get; set; }


    }
}
