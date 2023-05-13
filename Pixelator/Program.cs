
using System.Drawing;


string ColorToHex(Color color)
{
    string hex = "#" + color.R.ToString("X2") + color.G.ToString("X2") + color.B.ToString("X2");
    return hex;
}

string rutaImagen = "snoopy.png";

List<string> lines = new List<string>();
using (Bitmap imagen = new Bitmap(rutaImagen))
{
   for (int y = 0; y < imagen.Height; y++)
    {
        for (int x = 0; x < imagen.Width; x++)
        {            
            Color color = imagen.GetPixel(x, y);

            if (color.A > 0)
            {
                string colorHex = ColorToHex(color);

                var newLine = $"calc(var(--pixel-size) * {x}) calc(var(--pixel-size) * {y}) {colorHex}";

                lines.Add(newLine);
            }
        }
    }
}

var content = string.Join(',', lines);
File.WriteAllText(Path.ChangeExtension(rutaImagen, "css"), content);