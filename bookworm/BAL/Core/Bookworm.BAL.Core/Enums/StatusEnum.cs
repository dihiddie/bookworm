using Bookworm.BAL.Core.Attributes;

namespace Bookworm.BAL.Core.Enums
{
    public enum StatusEnum
    {
        [Color(ColorEnum.Gray)]
        NotFinished,
        [Color(ColorEnum.Green)]
        Readed,
        [Color(ColorEnum.Yellow)]
        WantToRead,
        [Color(ColorEnum.Blue)]
        Bought,
        [Color(ColorEnum.Red)]
        Favorite,
        [Color(ColorEnum.DarkGreen)]
        ReadingNow
    }
}
