namespace Assets.Scripts.Map.Obstacles
{
    public class Helicopter : Obstacle {

        public bool activated;

        public Helicopter(Direction orientation) : base(orientation) {
            activated = true;
        }

        public override void ExecuteAction() {
            activated = !activated;
        }

    }

}