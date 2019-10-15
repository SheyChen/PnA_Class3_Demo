﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Coordinate3D;

namespace Manipulators
{
    public class Puma
    {
        public Point3D Base_pt;
        public Point3D pt1;
        public Point3D pt2;
        public Point3D pt3;
        public Point3D pt4;
        public Vector3D armb_1;
        public Vector3D arm1_2;
        public Vector3D arm2_3;
        public Vector3D arm3_4;
        public Puma()
        {
            Point3D Base_pt = new Point3D(0, 0, 0);
            Point3D pt1 = new Point3D(0, 0, 100);
            Point3D pt2 = new Point3D(0, 100, 100);
            Point3D pt3 = new Point3D(0, 200, 50);
            Vector3D armb_1 = new Vector3D(0, 0, 100);
            Vector3D arm1_2 = new Vector3D(0, 100, 100);
            Vector3D arm2_3 = new Vector3D(0, 200, 50);
        }
        public Puma(Point3D _Base_pt, Point3D _pt1, Point3D _pt2, Point3D _pt3)
        {
                this.Base_pt = _Base_pt;
                this.pt1 = _pt1;
                this.pt2 = _pt2;
                this.pt3 = _pt3;
                this.armb_1 = Point3D.Distance(_Base_pt, _pt1);
                this.arm1_2 = Point3D.Distance(_pt1, _pt2);
                this.arm2_3 = Point3D.Distance(_pt2, _pt3);
        }

    }
    public class Scara
    {
        public Point3D Base_pt;
        public Point3D pt1;
        public Point3D pt2;
        public Point3D pt3;
        public Vector3D armb_1;
        public Vector3D arm1_2;
        public Vector3D arm2_3;
        public Scara()
        {
            Point3D Base_pt = new Point3D(0, 0, 0);
            Point3D pt1 = new Point3D(0, 0, 100);
            Point3D pt2 = new Point3D(0, 100, 100);
            Point3D pt3 = new Point3D(100, 100, 100);
            Vector3D armb_1 = new Vector3D(0, 0, 100);
            Vector3D arm1_2 = new Vector3D(0, 100, 0);
            Vector3D arm2_3 = new Vector3D(100, 0, 0);
        }
        public Scara(Point3D _Base_pt, Point3D _pt1, Point3D _pt2, Point3D _pt3)
        {
            this.Base_pt = _Base_pt;
            this.pt1 = _pt1;
            this.pt2 = _pt2;
            this.pt3 = _pt3;
            this.armb_1 = Point3D.Distance(_Base_pt, _pt1);
            this.arm1_2 = Point3D.Distance(_pt1, _pt2);
            this.arm2_3 = Point3D.Distance(_pt2, _pt3);
        }
    }
    
}
