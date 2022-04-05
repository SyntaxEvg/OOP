

using System.Drawing;
using System.Drawing;
public class Figure
{/// <summary>
/// цвет фигуры
/// </summary>
    private Color _color;
    /// <summary>
    /// состояние «видимое/невидимое».
    /// </summary>
    private bool _isVisible;
    private System.Drawing.Point _motion;


    public Color Color => _color;
    public bool IsVisible => _isVisible;

    public Figure(Color color, bool isVisible, System.Drawing.Point center)
    {
        _color = color;
        _isVisible = isVisible;
        _motion = center;
    }

    public void ChangeColor(Color changeTo)
    {
        _color = changeTo;
    }
    /// <summary>
    /// сдвиг по  горизонту
    /// </summary>
    /// <param name="offset"></param>
    public void MoveHorizontal(int offset)
    {
        _motion.X += offset;
    }

    public void MoveVertical(int offset)
    {
        _motion.Y += offset;
    }

    public override string ToString()
    {
        return string.Format("Figure: {0}, Color: {1}, IsVisible: {2}, Center: X: {3} Y: {4}",
            this.GetType().Name,
            this.Color,
            this.IsVisible,
            this._motion.X,
            this._motion.Y);
    }
}
