namespace Game.Scripts.GameMechanics.Weapons.Crosshairs
{
    public interface ICrosshairChanger
    {
        public void Change();

        public void UndoChange();
    }
}