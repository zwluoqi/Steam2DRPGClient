namespace Game.View.TriggerResult
{
    public class ViewTriggerResultHeroBorn:ViewTriggerResult
    {
        protected override void OnTrigger()
        {
            foreach (var sceneItem in sceneItems)
            {
                manager.TriggerSceneItem(sceneItem);    
            }
        }
    }
}