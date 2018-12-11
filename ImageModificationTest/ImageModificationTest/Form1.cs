using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Xna.Framework;

namespace ImageModificationTest
{
    public partial class Form1 : Form
    {
        ColorHeightMap heightMap;

        public Form1()
        {
            InitializeComponent();

            heightMap = new ColorHeightMap(500, 800, null);

            seedUpDown.Maximum = int.MaxValue;

            seedUpDown.Value = heightMap.MapSeed;

            mapHeightUpDown.Value = heightMap.MapHeight;
            mapWidthUpDown.Value = heightMap.MapWidth;
        }

        private void btnNoise_Click(object sender, EventArgs e)
        {
            waterWeatherBtn.Enabled = true;

            btnNoise.Enabled = false;

            NoiseMapParams mapParams = new NoiseMapParams();
            mapParams.amplitude = (float)amplitudeUpDown.Value;
            mapParams.frequancy = (float)frequencyUpDown.Value;
            mapParams.lacunarity = (float)lacunarityUpDown.Value;
            mapParams.octaves = (int)octaveUpDown.Value;
            mapParams.persistance = (float)persistanceUpDown.Value;

            bool doColor;
            int? newSeed = null;

            if (radioButtonColorMap.Checked) doColor = true;
            else doColor = false;

            if (heightMap.MapSeed != seedUpDown.Value) newSeed = (int)seedUpDown.Value;

            heightMap.GenerateNoise(mapParams, doColor, newSeed);

            DrawMap();

            btnNoise.Enabled = true;
        }

        private void waterWeatherBtn_Click(object sender, EventArgs e)
        {
            waterWeatherBtn.Enabled = false;
            btnNoise.Enabled = false;

            ErosionParams erosionParams = new ErosionParams();
            erosionParams.Kq = 10;
            erosionParams.Kw = 0.001f;
            erosionParams.Kr = 0.9f;
            erosionParams.Kd = 0.02f;
            erosionParams.Ki = 0.1f;
            erosionParams.minSlope = 0.05f;
            erosionParams.g = 20;

            int iterations = (int)nudWeatheringDroplets.Value;

            Droplet droplet = new Droplet();
            droplet.genDropletErosion(iterations, erosionParams, heightMap.noiseMap);


            DrawMap();

            waterWeatherBtn.Enabled = true;
            btnNoise.Enabled = true;
            //seamlessMeridianBtn.Enabled = true;
        }

        Bitmap DrawMap()
        {
            Bitmap bitmap;

            if (radioButtonColorMap.Checked) pbxMain.Image = heightMap.MapBitmapToColor(false);
            else if (radioButtonBlackWhiteMap.Checked) pbxMain.Image = heightMap.MapBitmapToGrayScale(false);
            else if (radioButtonWaterTableMap.Checked) pbxMain.Image = heightMap.MapBitmapToWaterTable(false, (double)waterTableUpDown.Value);

            bitmap = (Bitmap)pbxMain.Image;

            return bitmap;
        }

        private void randomSeedBtn_Click(object sender, EventArgs e)
        {
            seedUpDown.Value = new System.Random().Next(0, int.MaxValue);
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            DrawMap().Save(@"image.png");
        }

        private void flattenPolesBtn_Click(object sender, EventArgs e)
        {
            //double avgHeightNorth = 0;
            //double avgHeightSouth = 0;

            //for (int i = 0; i < noiseMap.GetLength(1); i++)
            //{
            //    avgHeightNorth += noiseMap[0, i];
            //    avgHeightSouth += noiseMap[noiseMap.GetLength(0) - 1, i];
            //}

            //avgHeightNorth /= noiseMap.GetLength(1);
            //avgHeightSouth /= noiseMap.GetLength(1);

            //double blend = 0.000;
            //double coverage = 0.15 * noiseMap.GetLength(1);

            //for (int y = 0; y < noiseMap.GetLength(1); y++)
            //{
            //    for (int x = 0; x < noiseMap.GetLength(0); x++)
            //    {
            //        noiseMap[x, y] = (noiseMap[x, y] * blend) + (avgHeightNorth * (1 - blend));
            //    }

            //    blend = (double)y / coverage;
            //    if (y > coverage) break;
            //}

            //blend = 0;

            //for (int y = noiseMap.GetLength(1) - 1; y > 0; y--)
            //{
            //    for (int x = noiseMap.GetLength(0) - 1; x > 0; x--)
            //    {
            //        noiseMap[x, y] = (noiseMap[x, y] * blend) + (avgHeightSouth * (1 - blend));
            //    }

            //    blend = (noiseMap.GetLength(1) - (double)y) / coverage;
            //    if (noiseMap.GetLength(1) - (double)y > coverage) break;
            //}

            //colorMapping(false);

            //pbxMain.Image = bitmap;
        }

        private void seamlessMeridianBtn_Click(object sender, EventArgs e)
        {
            //double avgHeightWest = 0;
            //double avgHeightEast = 0;
            //double avgHeight = 0;

            //for (int i = 0; i < noiseMap.GetLength(0); i++)
            //{
            //    avgHeightWest += noiseMap[i, 0];
            //    avgHeightEast += noiseMap[i, noiseMap.GetLength(1) - 1];
            //}

            //avgHeightWest /= noiseMap.GetLength(0);
            //avgHeightEast /= noiseMap.GetLength(0);

            //avgHeight = (avgHeightWest + avgHeightEast) / 2;

            //double blend = 0.000;
            //double coverage = 0.03 * noiseMap.GetLength(0);

            //for (int x = 0; x < noiseMap.GetLength(0); x++)
            //{
            //    for (int y = 0; y < noiseMap.GetLength(1); y++)
            //    {
            //        noiseMap[x, y] = (noiseMap[x, y] * blend) + (avgHeight * (1 - blend));
            //    }

            //    blend = (double)x / coverage;
            //    if (x > coverage) break;
            //}

            //blend = 0;

            //for (int x = noiseMap.GetLength(0) - 1; x > 0; x--)
            //{
            //    for (int y = noiseMap.GetLength(1) - 1; y > 0; y--)
            //    {
            //        noiseMap[x, y] = (noiseMap[x, y] * blend) + (avgHeight * (1 - blend));
            //    }

            //    blend = (noiseMap.GetLength(0) - (double)x) / coverage;
            //    if (noiseMap.GetLength(0) - (double)x > coverage) break;
            //}

            //colorMapping(false);

            //pbxMain.Image = bitmap;

            //flattenPolesBtn.Enabled = true;
        }

        private void DrapMapBtn_Click(object sender, EventArgs e)
        {
            DrawMap();
        }

    }
}
