using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Xna.Framework;
using System.Threading;

namespace ImageModificationTest
{
    public partial class Form1 : Form
    {
        ColorHeightMap heightMap;

        public Form1()
        {
            InitializeComponent();

            heightMap = new ColorHeightMap(500, 500, null);

            seedUpDown.Maximum = int.MaxValue;

            seedUpDown.Value = heightMap.MapSeed;

            mapHeightUpDown.Value = heightMap.MapHeight;
            mapWidthUpDown.Value = heightMap.MapWidth;

            // no longer relevant now using sphereical mapping
            flattenPolesBtn.Enabled = false;
            seamlessMeridianBtn.Enabled = false;
        }

        private void btnNoise_Click(object sender, EventArgs e)
        {
            waterWeatherBtn.Enabled = true;

            btnNoise.Enabled = false;

            // take in values from form and package them for the hight map generation
            NoiseMapParams mapParams = new NoiseMapParams();
            mapParams.amplitude = (float)amplitudeUpDown.Value;
            mapParams.frequancy = (float)frequencyUpDown.Value;
            mapParams.lacunarity = (float)lacunarityUpDown.Value;
            mapParams.octaves = (int)octaveUpDown.Value;
            mapParams.persistance = (float)persistanceUpDown.Value;

            bool doColor;
            int? newSeed = null;

            // some older that needs to be replaced but......
            if (radioButtonColorMap.Checked) doColor = true;
            else doColor = false;

            // is the seed changed update it, i dont think this actually works
            if (heightMap.MapSeed != seedUpDown.Value) newSeed = (int)seedUpDown.Value;

            // see color height map class
            heightMap.GenerateNoise(mapParams, doColor, newSeed);

            // draws map based on form radio buttons
            DrawMap();

            // generation takes a bit so dissabling then enabling the button was needed
            btnNoise.Enabled = true;
        }

        private void waterWeatherBtn_Click(object sender, EventArgs e)
        {
            waterWeatherBtn.Enabled = false;
            btnNoise.Enabled = false;

            // parames that the errosion class needed see droplet class for more info
            ErosionParams erosionParams = new ErosionParams();
            erosionParams.Kq = 10;
            erosionParams.Kw = 0.001f;
            erosionParams.Kr = 0.9f;
            erosionParams.Kd = 0.02f;
            erosionParams.Ki = 0.1f;
            erosionParams.minSlope = 0.05f;
            erosionParams.g = 20;

            // how many droplets you want
            int iterations = (int)nudWeatheringDroplets.Value;

            // run it
            Droplet droplet = new Droplet();
            droplet.genDropletErosion(iterations, erosionParams, heightMap.noiseMap);

            // draw it
            DrawMap();

            waterWeatherBtn.Enabled = true;
            btnNoise.Enabled = true;
            //seamlessMeridianBtn.Enabled = true;
        }

        Bitmap DrawMap() // what radio button is true? draw that style
        {
            Bitmap bitmap;

            if (radioButtonColorMap.Checked) pbxMain.Image = heightMap.MapBitmapToColor(false);
            else if (radioButtonBlackWhiteMap.Checked) pbxMain.Image = heightMap.MapBitmapToGrayScale(false);
            else if (radioButtonWaterTableMap.Checked) pbxMain.Image = heightMap.MapBitmapToWaterTable(false, (double)waterTableUpDown.Value);

            bitmap = (Bitmap)pbxMain.Image;

            return bitmap;
        }

        // randomizes the seed
        private void randomSeedBtn_Click(object sender, EventArgs e)
        {
            seedUpDown.Value = new System.Random().Next(0, int.MaxValue);
        }

        // saves the map to a file in the root folder the exe is in
        private void saveBtn_Click(object sender, EventArgs e)
        {
            DrawMap().Save(@"image.png");
        }


        // no longer relevant now using sphereical mapping
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

        // no longer relevant now using sphereical mapping
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

        // DRAW
        private void DrapMapBtn_Click(object sender, EventArgs e)
        {
            DrawMap();
        }

    }
}
