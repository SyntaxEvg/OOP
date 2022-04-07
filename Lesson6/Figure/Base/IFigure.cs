using System.Drawing;

public interface IFigure
{
    Color Color { get; }
    bool IsVisible { get; }

    void ChangeColor(Color changeTo);
    void MoveHorizontal(int offset);
    void MoveVertical(int offset);
    string ToString();
}