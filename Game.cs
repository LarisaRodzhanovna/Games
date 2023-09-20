namespace Games
{
    /// <summary>
    /// Модель игры
    /// </summary>
    public class Game
    {
        /// <summary>
        /// Идентификатор 
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Название 
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Разработчик 
        /// </summary>
        public string Developer { get; set; }

        /// <summary>
        /// Жанры 
        /// </summary>
        public List<string> Genres { get; set; }
    }
}
