using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using Microsoft.Xna.Framework;

namespace ImageModificationTest
{
    struct NoiseMapParams
    {
        public int octaves;
        public double frequancy,
                      amplitude,
                      persistance,
                      lacunarity;
    }

    class ColorHeightMap
    {
        Bitmap bitmap;
        System.Drawing.Color color;
        public double[,] noiseMap;

        double minNoiseHeight;
        double maxNoiseHeight;

        private int mapHeight;
        private int mapWidth;

        NoiseMapParams noiseMapParams;

        public int MapHeight { get { return mapHeight; } protected set { mapHeight = value; } }
        public int MapWidth { get { return mapWidth; } protected set { mapWidth = value; } }

        System.Random prng;

        private int mapSeed;

        public int MapSeed { get { return mapSeed; } protected set { mapSeed = value; } }

        public ColorHeightMap(int _mapHeight, int _mapWidth, int? _seed)
        {
            prng = new System.Random();

            // if seed is given use it else make a random one
            if (_seed != null)
            {
                mapSeed = (int)_seed;
                prng = new System.Random((int)_seed);
            }
            else
            {
                mapSeed = prng.Next(0, int.MaxValue);
                prng = new System.Random(mapSeed);
            }

            color = new System.Drawing.Color();

            mapWidth = _mapWidth;
            mapHeight = _mapHeight;

            bitmap = new Bitmap(mapWidth, mapHeight);
            noiseMap = new double[mapWidth, mapHeight];
        }

        public Bitmap ChangeSize(int _mapHeight, int _mapWidth, bool doColor)
        {
            mapWidth = _mapWidth;
            mapHeight = _mapHeight;

            bitmap = new Bitmap(mapWidth, mapHeight);
            noiseMap = new double[mapWidth, mapHeight];

            GenerateNoise(noiseMapParams, doColor, mapSeed);

            return bitmap;
        }

        void LatLonToXYZ(double lat, double lon, ref double x, ref double y, ref double z)
        {
            // converts longitude and latitude coordinates to XYZ coordinates

            double r =     Math.Cos(lon * (Math.PI / 180));
                   x = r * Math.Cos(lat * (Math.PI / 180));
                   y =     Math.Sin(lon * (Math.PI / 180));
                   z = r * Math.Sin(lat * (Math.PI / 180));
        }
        void LatLonToXYZ(double lat, double lon, ref double x, ref double y, ref double z, double freq, Vector2 octOffset)
        {
            // converts longitude and latitude coordinates to XYZ coordinates with frequency and octave offsets

            double r = Math.Cos(lon * (Math.PI / 180));
            x = r * Math.Cos(lat * (Math.PI / 180)) * freq + octOffset.X;
            y = Math.Sin(lon * (Math.PI / 180)) * freq + octOffset.Y;
            z = r * Math.Sin(lat * (Math.PI / 180)) * freq + octOffset.X;
        }

        public Bitmap GenerateNoise(NoiseMapParams mapParams, bool doColor, int? newSeed)
        {
            if (newSeed != null)
            {
                prng = new System.Random((int)newSeed);
            }

            // mapParams holds all the info needed to make a varied hightmap
            //octaves, frequancy, amplitude, persistance, lacunarity;
            Vector2[] octaveOffsets = new Vector2[mapParams.octaves];

            // generate octave offsets
            for (int i = 0; i < mapParams.octaves; i++)
            {
                float offsetX = prng.Next(0, 1500000);
                float offsetY = prng.Next(0, 1500000);
                octaveOffsets[i] = new Vector2(offsetX, offsetY);
            }

            // used for lerping later
            minNoiseHeight = double.MaxValue;
            maxNoiseHeight = double.MinValue;

            // fill temp data
            int octaves = mapParams.octaves;
            double frequancy = mapParams.frequancy;
            double amplitude = mapParams.amplitude;
            double persistance = mapParams.persistance;
            double lacunarity = mapParams.lacunarity;

            double heightValue;
            double perlinValue;

            // Define our map area in latitude/longitude
            double southLatBound = -180;
            double northLatBound = 180;
            double westLonBound = -90;
            double eastLonBound = 90;

            double lonExtent = eastLonBound - westLonBound;
            double latExtent = northLatBound - southLatBound;

            double xDelta = lonExtent / (double)mapWidth;
            double yDelta = latExtent / (double)mapHeight;

            double curLon = westLonBound;
            double curLat = southLatBound;

            // Loop through each tile using its lat/long coordinates
            for (int x = 0; x < mapWidth; x++)
            {
                curLon = westLonBound;

                for (int y = 0; y < mapHeight; y++)
                {
                    frequancy = mapParams.frequancy;
                    amplitude = mapParams.amplitude;
                    heightValue = 0;

                    //Noise range
                    //double x1 = 0, x2 = 1;
                    //double y1 = 0, y2 = 1;
                    //double dx = x2 - x1;
                    //double dy = y2 - y1;

                    double x1 = 0, y1 = 0, z1 = 0;
                    
                    for (int i = 1; i < octaves + 1; i++)
                    {
                        //Sample noise at smaller intervals
                        //double s = (double)x / bitmap.Width;
                        //double t = (double)y / bitmap.Height;

                        // Calculate our 4D coordinates, this is used to make the output tileable
                        //double nx = x1 + Math.Cos(s * 2 * Math.PI) * dx / (2 * Math.PI) * frequancy + octaveOffsets[i - 1].X;
                        //double ny = y1 + Math.Cos(t * 2 * Math.PI) * dy / (2 * Math.PI) * frequancy + octaveOffsets[i - 1].Y;
                        //double nz = x1 + Math.Sin(s * 2 * Math.PI) * dx / (2 * Math.PI) * frequancy + octaveOffsets[i - 1].X;
                        //double nw = y1 + Math.Sin(t * 2 * Math.PI) * dy / (2 * Math.PI) * frequancy + octaveOffsets[i - 1].Y;

                        // mapping the perlin noise sphereically
                        LatLonToXYZ(curLat, curLon, ref x1, ref y1, ref z1, frequancy, octaveOffsets[i - 1]);
                        //LatLonToXYZ(curLat, curLon, ref x1, ref y1, ref z1);

                        // pull height value
                        perlinValue = OpenSimplexNoise.noise(x1, y1, z1);
                        heightValue += perlinValue * amplitude * frequancy + octaveOffsets[i - i].Y;

                        amplitude *= persistance;
                        frequancy *= lacunarity;
                    }



                    // keep track of the max and min values found
                    if (heightValue > maxNoiseHeight) maxNoiseHeight = heightValue;
                    else if (heightValue < minNoiseHeight) minNoiseHeight = heightValue;

                    // save it
                    noiseMap[x, y] = heightValue;

                    curLon += xDelta;
                }
                curLat += yDelta;
            }

            
            if (doColor) MapBitmapToColor(true);
            else MapBitmapToGrayScale(true);

            return bitmap;
        }
        
        public Bitmap MapBitmapToColor(bool doLerp)
        {
            int colorMaping;

            int colorValRed = 0;
            int colorValGreen = 0;
            int colorValBlue = 0;

            for (int y = 0; y < bitmap.Height; y++)
            {
                for (int x = 0; x < bitmap.Width; x++)
                {
                    if (doLerp) noiseMap[x, y] = Perlin.invertedLerp(maxNoiseHeight, minNoiseHeight, noiseMap[x, y]);

                    //progressBar.Value = (int)(Perlin.invertedLerp(0, bitmap.Height * bitmap.Width, y * x) * 100);

                    colorMaping = (int)(noiseMap[x, y] * 255 * 6);

                    if (colorMaping <= 255) //black to blue
                    {
                        colorValRed = 0;
                        colorValGreen = 0;
                        colorValBlue = colorMaping;
                    }
                    else if (colorMaping > 255 && colorMaping <= 255 * 2) //blue to cyan
                    {
                        colorValRed = 0;
                        colorValGreen = colorMaping - 255;
                        colorValBlue = 255;
                    }
                    else if (colorMaping > 255 * 2 && colorMaping <= 255 * 3) //cyan to green
                    {
                        colorValRed = 0;
                        colorValGreen = 255;
                        colorValBlue = ((255 * 6) - colorMaping) - 255 * 3;
                    }
                    else if (colorMaping > 255 * 3 && colorMaping <= 255 * 4) //green to yellow
                    {
                        colorValRed = colorMaping - 255 * 3;
                        colorValGreen = 255;
                        colorValBlue = 0;
                    }
                    else if (colorMaping > 255 * 4 && colorMaping <= 255 * 5) //yellow to red
                    {
                        colorValRed = 255;
                        colorValGreen = ((255 * 6) - colorMaping) - 255;
                        colorValBlue = 0;
                    }
                    else if (colorMaping > 255 * 5) //red to white
                    {
                        colorValRed = 255;
                        colorValGreen = colorMaping - 255 * 5;
                        colorValBlue = colorMaping - 255 * 5;
                    }

                    color = System.Drawing.Color.FromArgb(colorValRed, colorValGreen, colorValBlue);
                    bitmap.SetPixel(x, y, color);
                }
            }

            return bitmap;
        }

        public Bitmap MapBitmapToGrayScale(bool doLerp) // draws a gray scale map
        {
            int colorMaping;

            int colorValRed = 0;
            int colorValGreen = 0;
            int colorValBlue = 0;

            for (int y = 0; y < bitmap.Height; y++)
            {
                for (int x = 0; x < bitmap.Width; x++)
                {
                    if (doLerp) noiseMap[x, y] = Perlin.invertedLerp(maxNoiseHeight, minNoiseHeight, noiseMap[x, y]);

                    colorMaping = (int)(noiseMap[x, y] * 255);

                    colorValRed = colorMaping;
                    colorValGreen = colorMaping;
                    colorValBlue = colorMaping;
                    

                    color = System.Drawing.Color.FromArgb(colorValRed, colorValGreen, colorValBlue);
                    bitmap.SetPixel(x, y, color);
                }
            }

            return bitmap;
        }

        public Bitmap MapBitmapToTopographical(bool doLerp) // no......need to find a better way
        {
            int colorMaping;

            int colorValRed = 0;
            int colorValGreen = 0;
            int colorValBlue = 0;

            for (int y = 0; y < bitmap.Height; y++)
            {
                for (int x = 0; x < bitmap.Width; x++)
                {
                    if (doLerp) noiseMap[x, y] = Perlin.invertedLerp(maxNoiseHeight, minNoiseHeight, noiseMap[x, y]);

                    //colorMaping = (int)(noiseMap[x, y] * 255);

                    if (
                        (noiseMap[x, y] >= 0.105 && noiseMap[x, y] <= 0.115) ||
                        (noiseMap[x, y] >= 0.205 && noiseMap[x, y] <= 0.215) ||
                        (noiseMap[x, y] >= 0.305 && noiseMap[x, y] <= 0.315) ||
                        (noiseMap[x, y] >= 0.405 && noiseMap[x, y] <= 0.415) ||
                        (noiseMap[x, y] >= 0.505 && noiseMap[x, y] <= 0.515) ||
                        (noiseMap[x, y] >= 0.605 && noiseMap[x, y] <= 0.615) ||
                        (noiseMap[x, y] >= 0.705 && noiseMap[x, y] <= 0.715) ||
                        (noiseMap[x, y] >= 0.805 && noiseMap[x, y] <= 0.815) ||
                        (noiseMap[x, y] >= 0.905 && noiseMap[x, y] <= 0.915))
                    {
                        colorValRed = 119; // topographical red
                        colorValGreen = 66;
                        colorValBlue = 52;
                    }
                    else
                    {
                        colorValRed = 212; // topographical green
                        colorValGreen = 255;
                        colorValBlue = 173;
                    }

                    color = System.Drawing.Color.FromArgb(colorValRed, colorValGreen, colorValBlue);
                    bitmap.SetPixel(x, y, color);
                }
            }

            return bitmap;
        }

        public Bitmap MapBitmapToWaterTable(bool doLerp, double waterHeight)
        {
            int colorMaping;

            int colorValRed = 0;
            int colorValGreen = 0;
            int colorValBlue = 0;

            for (int y = 0; y < bitmap.Height; y++)
            {
                for (int x = 0; x < bitmap.Width; x++)
                {
                    if (doLerp) noiseMap[x, y] = Perlin.invertedLerp(maxNoiseHeight, minNoiseHeight, noiseMap[x, y]);

                    colorMaping = (int)(noiseMap[x, y] * 255);

                    if (noiseMap[x, y] <= waterHeight)
                    {
                        colorValRed = 200; // topographical water
                        colorValGreen = 231;
                        colorValBlue = 236;
                    }
                    else
                    {
                        colorValRed = 212; // topographical green
                        colorValGreen = 255;
                        colorValBlue = 173;
                    }

                    color = System.Drawing.Color.FromArgb(colorValRed, colorValGreen, colorValBlue);
                    bitmap.SetPixel(x, y, color);
                }
            }

            return bitmap;
        }
    }
}
