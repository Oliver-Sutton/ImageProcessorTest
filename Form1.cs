using ImageProcessor;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace ImageProcessorTest
{
  public partial class Form1 : Form
  {
    private readonly string filePath = "C:\\Users\\Ollie\\source\\repos\\ImageProcessor\\sqaures.png";

    public Form1()
    {
      InitializeComponent();
    }

    private void ButtonPickColour_Click(object sender, EventArgs e)
    {
      var result = colorDialog.ShowDialog();
      
      if (result == DialogResult.OK)
      {
        var selectedColour = colorDialog.Color;

        // Do the image changing here.
        byte[] photoBytes = File.ReadAllBytes(filePath);
        using (MemoryStream inStream = new MemoryStream(photoBytes))
        using (MemoryStream outStream = new MemoryStream())
        using (ImageFactory imageFactory = new ImageFactory(preserveExifData: true))
        {
          imageFactory.Load(inStream).ReplaceColor(Color.Black, selectedColour).Save(outStream);

          pictureBox.Image = Image.FromStream(outStream);
        }

      }
    }
  }
}
