using System.Collections.Generic;

namespace MemoryGameLogic
{
    public static class Images
    {
        private static readonly string sr_DefaultImageRearSide = "https://media.hearthpwn.com/attachments/104/176/power-core.png";
        private static readonly Dictionary<char, string> sr_CharToImageDictionary =
            new Dictionary<char, string> { { 'A', "https://img.freepik.com/premium-vector/cute-alpaca-with-heart-flowers-postcard_603291-483.jpg?w=360" },
                                           { 'B', "https://img.freepik.com/premium-vector/cute-animated-beautiful-bull-that-is-scared-animal-creative-vector-illustration_585140-86.jpg?w=740" },
                                           { 'C', "https://img.freepik.com/premium-vector/cute-yellow-kitten-various-types-use_596556-52.jpg?w=740" },
                                           { 'D', "https://img.freepik.com/premium-vector/cute-couple-happy-animated-dogs-cartoon-icon-animated-vector_585140-83.jpg?w=740" },
                                           { 'E', "https://img.freepik.com/premium-vector/three-cute-baby-elephant_120675-9.jpg?w=740" },
                                           { 'F', "https://img.freepik.com/free-vector/happy-fox-outstretching-hands-while-walking_74855-96.jpg?w=740&t=st=1663071148~exp=1663071748~hmac=9f6879cc4d7a2f26024d1e7631dc408339766e6378bd08d3ea33004f2b79507c" },
                                           { 'G', "https://img.freepik.com/free-vector/cute-mandrill-flat-style_1308-113452.jpg?t=st=1663071186~exp=1663071786~hmac=a71704d11e70468ceb6f90967cbe0697920a8f25a7f1472ab49db385833df3fa" },
                                           { 'H', "https://img.freepik.com/free-photo/fun-horse-3d-illustration_183364-113511.jpg?w=900&t=st=1663071366~exp=1663071966~hmac=01347aff392627cf1cc3b6b1a6e7c098e9e20bb8fa3e48da2b141f9075b06ce6" },
                                           { 'I', "https://img.freepik.com/free-vector/cute-deer-flat-cartoon-style_1308-111349.jpg?t=st=1663071443~exp=1663072043~hmac=bd5b847113d88020b341d1d6469095f98c860ac55442cac0bb57fec31e1f4e43" },
                                           { 'J', "https://img.freepik.com/free-vector/squirrel-playing-skateboard-whiting_1308-104292.jpg?w=740&t=st=1663071587~exp=1663072187~hmac=297ac9d22954f3e506d2ef0ac3908ad9872cf37bb0c7968c48c585776aa7f247" },
                                           { 'K', "https://img.freepik.com/premium-vector/cartoon-cute-koala-holding-megaphone_70172-2349.jpg?w=740" },
                                           { 'L', "https://img.freepik.com/premium-vector/cute-adorable-lion-smile-waving-hand-vector-cartoon-illustration_226569-44.jpg?w=740" },
                                           { 'M', "https://img.freepik.com/premium-vector/cute-mouse-cartoon-rat-character-smiling-animal_543062-633.jpg?w=360" },
                                           { 'N', "https://img.freepik.com/premium-vector/cute-tiger-cartoon-mascot-illustration-design-animal-mascot-storybook-animation-print-product_357749-1646.jpg?w=740" },
                                           { 'O', "https://img.freepik.com/premium-vector/cartoon-owl-flapping-wings-smiling_70172-1220.jpg?w=826" },
                                           { 'P', "https://img.freepik.com/premium-vector/cartoon-happy-toucan-tree-stump_29190-1017.jpg?w=740" },
                                           { 'Q', "https://img.freepik.com/premium-vector/this-cartoon-clipart-shows-seal-vector-illustration_576561-1278.jpg?w=740" },
                                           { 'R', "https://img.freepik.com/premium-vector/cute-bunny-icon-kids-stickers-tshirt-designs_647530-259.jpg?w=740" } };

        public static string RearSideDefaultImageLocation
        {
            get { return sr_DefaultImageRearSide; }
        }

        public static void GetImageLocationCorrespondingToSlotValue(char i_Value, out string io_ImageLocation)
        {
            sr_CharToImageDictionary.TryGetValue(i_Value, out io_ImageLocation);
        }
    }
}
