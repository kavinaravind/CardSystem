using CoLocatedCardSystem.CollaborationWindow.DocumentModule;
using Windows.Foundation;

namespace CoLocatedCardSystem.CollaborationWindow.InteractionModule
{
    public class SemanticCard:Card
    {
        User owner = User.ALEX;
        LayerBase[] layers;
        int currentLayer;
        Document document;
        private const int LAYER_NUMBER= 4;
        
        /// <summary>
        /// Initialize a semantic card.
        /// </summary>
        /// <param name="cardID"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="position"></param>
        /// <param name="scale"></param>
        /// <param name="rotation"></param>
        internal override void Init(string cardID, UserInfo userInfo)
        {
            base.Init(cardID, userInfo);
            layers = new LayerBase[LAYER_NUMBER];
            layers[0] = new Layer1();
            layers[1] = new Layer2();
            layers[2] = new Layer3();
            layers[3] = new Layer4();
            foreach (var layer in layers) {
                layer.Init(this);
            }
            this.Children.Add(layers[0]);

        }
        /// <summary>
        /// Load the document to the card. Set the content to all the layers.
        /// </summary>
        /// <param name="document"></param>
        internal void LoadDocument(Document document) {
            this.document = document;
            foreach (var layer in layers)
            {
                layer.SetArticle(this.document);
            }
        }
    }
}
