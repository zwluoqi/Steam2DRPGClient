public class SceneRandomHeroItem:SceneHeroItem
{
        public override SceneItemType sceneItemType
        {
                get
                {
                        return SceneItemType.HeroCollection;
                }
        }

        public int counter = 1;
}