using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ImageModificationTest
{
    // found class online translated from C++ to C#

    struct ErosionParams
    {
        //Kq and minSlope are for soil carry capacity (see the formula above).
        //Kw is water evaporation speed.
        //Kr is erosion speed (how fast the soil is removed).
        //Kd is deposition speed (how fast the extra sediment is dropped).
        //Ki is direction inertia. Higher values make channel turns smoother.
        //g is gravity that accelerates the flows.

        public float Kq, 
                     Kw,
                     Kr,
                     Kd,
                     Ki,
                     minSlope,
                     g;
    }

    class Droplet
    {
        void DEPOSIT_AT(int X, int Z, float W, double[,] hMap, float ds)
        {
            float delta = ds * (W);
            if (X >= hMap.GetLength(0) || X < 0 || Z >= hMap.GetLength(1) || Z < 0)
            {
                X = X;
            }
            else
            {
                hMap[X, Z] += delta;
            }
        }

        void ERODE(int X, int Z, float W, double[,] hMap, float ds)
        {
            float delta = ds * (W);
            if (X >= hMap.GetLength(0) || X < 0 || Z >= hMap.GetLength(1) || Z < 0)
            {
                X = X;
            }
            else
            {
                hMap[X, Z] -= delta;
            }
        }

        public void genDropletErosion(int iterations, ErosionParams erosionParams, double[,] hMap)
        {
            Random rnd = new Random();

            float Kq = erosionParams.Kq, 
                  Kw = erosionParams.Kw,
                  Kr = erosionParams.Kr,
                  Kd = erosionParams.Kd,
                  Ki = erosionParams.Ki,
                  minSlope = erosionParams.minSlope,
                  Kg = erosionParams.g*2;
    
            //TempData<Point2[HMAP_SIZE*HMAP_SIZE]> erosion;

            float flt = 0;

            //erosion.fillMem32(*(uint32_t*)&flt);
            
            int MAX_PATH_LEN = hMap.GetLength(0) * 4;
            
            //int t0 = get_ref_time();
            
            uint longPaths=0, randomDirs=0, sumLen=0;

            for (int iter=0; iter < iterations; ++iter)
            {
                //if ((iter&0x3FFF) == 0 && iter!=0) show_splash("Calculating erosion", (iter+0.5f)/iterations);

                int xi = rnd.Next(0,hMap.GetLength(0) - 1);
                int zi = rnd.Next(0,hMap.GetLength(1) - 1);

                float xp = xi, zp = zi;
                float xf = 0, zf = 0;

                float h = (float)hMap[xi, zi];
                float s = 0, v = 0, w = 1;
                //vec4f scolor = zero4f();

                //if (xi + 1 >= hMap.GetLength(0)) xi = 0;
                //if (zi + 1 >= hMap.GetLength(1)) zi = 0;

                float h00 = h;
                float h10 = (float)hMap[xi+1, zi  ];
                float h01 = (float)hMap[xi  , zi+1];
                float h11 = (float)hMap[xi+1, zi+1];

                float dx = 0, dz = 0;

                uint numMoves = 0;

                for (; numMoves<MAX_PATH_LEN; ++numMoves)
                {
                    // calc gradient
                    float gx = h00 + h01 - h10 - h11;
                    float gz = h00 + h10 - h01 - h11;
                    //== better interpolated gradient?

                    // calc next pos
                    dx = (dx - gx) * Ki + gx;
                    dz = (dz - gz) * Ki + gz;

                    float dl = (float)Math.Sqrt(dx * dx + dz * dz);
                    
                    if (dl <= float.Epsilon)
                    {
                        // pick random dir
                        float a = (float)(rnd.Next() * (Math.PI * 2));
                              dx= (float)Math.Cos(a);
                              dz= (float)Math.Sin(a);
                              ++randomDirs;
                    }
                    else
                    {
                        dx /= dl;
                        dz /= dl;
                    }

                    float nxp = xp + dx;
                    float nzp = zp + dz;

                    // sample next height
                    int nxi = (int)Math.Floor(nxp);
                    int nzi = (int)Math.Floor(nzp);
                    float nxf = nxp - nxi;
                    float nzf = nzp - nzi;

                    if (nxi + 1 >= hMap.GetLength(0))
                    {
                        nxi = 0;
                    }
                    if (nxi < 0)
                    {
                        nxi = hMap.GetLength(0) - 2;
                    }
                    if (nzi + 1 >= hMap.GetLength(1))
                    {
                        nzi = 0;
                    }
                    if (nzi < 0)
                    {
                        nzi = hMap.GetLength(1) - 2;
                    }

                    float nh00 = (float)hMap[nxi  , nzi  ];
                    float nh10 = (float)hMap[nxi+1, nzi  ];
                    float nh01 = (float)hMap[nxi  , nzi+1];
                    float nh11 = (float)hMap[nxi+1, nzi+1];

                    float nh = (nh00 * (1-nxf) + nh10 * nxf) * (1 - nzf) + (nh01 * (1 - nxf)  + nh11 * nxf) * nzf;

                    // if higher than current, try to deposit sediment up to neighbour height
                    if (nh >= h)
                    {
                        float tds = (nh - h) + 0.001f;

                        if (tds >= s)
                        {
                            // deposit all sediment and stop
                            tds = s;

                            DEPOSIT_AT(xi, zi, (1 - xf) * (1 - zf), hMap, tds);
                            DEPOSIT_AT(xi + 1, zi, xf * (1 - zf), hMap, tds);
                            DEPOSIT_AT(xi, zi + 1, (1 - xf) * zf, hMap, tds);
                            DEPOSIT_AT(xi + 1, zi + 1, xf * zf, hMap, tds);
                            (h) += tds;
                            

                            s = 0;
                            break;
                        }

                        DEPOSIT_AT(xi, zi, (1 - xf) * (1 - zf), hMap, tds);
                        DEPOSIT_AT(xi + 1, zi, xf * (1 - zf), hMap, tds);
                        DEPOSIT_AT(xi, zi + 1, (1 - xf) * zf, hMap, tds);
                        DEPOSIT_AT(xi + 1, zi + 1, xf * zf, hMap, tds);
                        (h) += tds;

                        s -= tds;
                        v = 0;
                    }

                    // compute transport capacity
                    float dh = h - nh;
                    float slope = dh;
                    //float slope=dh/sqrtf(dh*dh+1);

                    float q = Math.Max(slope, minSlope) * v * w * Kq;

                    // deposit/erode (don't erode more than dh)
                    float ds = s - q;

                    if (ds >= 0)
                    {
                        // deposit
                        ds *= Kd;
                        //ds=minval(ds, 1.0f);

                        DEPOSIT_AT(xi, zi, (1 - xf) * (1 - zf), hMap, ds);
                        DEPOSIT_AT(xi + 1, zi, xf * (1 - zf), hMap, ds);
                        DEPOSIT_AT(xi, zi + 1, (1 - xf) * zf, hMap, ds);
                        DEPOSIT_AT(xi + 1, zi + 1, xf * zf, hMap, ds);
                        (dh) += ds;

                        s -= ds;
                    }
                    else
                    {
                        // erode
                        ds *= -Kr;
                        ds = Math.Min(ds, dh * 0.99f);

                        for (int z = zi - 1; z <= zi + 2; ++z)
                        {
                            float zo = z - zp;
                            float zo2 = zo * zo;

                            for (int x = xi - 1; x <= xi + 2; ++x)
                            {
                                float xo = x - xp;

                                float tw = 1 - (xo * xo + zo2) * 0.25f;
                                if (tw <= 0) continue;
                                tw *= 0.1591549430918953f;

                                ERODE(x, z, tw, hMap, ds);
                            }
                        }

                        dh-=ds;

                        s+=ds;
                    }

                    // move to the neighbour
                    v = (float)Math.Sqrt(v * v + Kg * dh);
                    w *= 1 - Kw;

                    xp = nxp; zp = nzp;
                    xi = nxi; zi = nzi;
                    xf = nxf; zf = nzf;

                    h = nh;
                    h00 = nh00;
                    h10 = nh10;
                    h01 = nh01;
                    h11 = nh11;
                }

                if (numMoves >= MAX_PATH_LEN)
                {
                    //debug("droplet #%d path is too long!", iter);
                    ++longPaths;
                }

                sumLen+=numMoves;
            }
        }
    }
}
