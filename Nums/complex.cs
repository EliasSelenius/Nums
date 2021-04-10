
namespace Nums {

    /*
        (a + bi) * (x + yi)

        ax + ayi + bix - by

        (a + bi) / (x + yi)

        a/x + a/yi + bi/x + bi/yi

    */

    /// <summary>A complex number with a real part and an imaginary part, a + bi</summary>
    public struct complex {

        /// <summary>The imaginary unit i.</summary>
        public static readonly complex imaginaryUnit = new complex(0, 1.0f);

        /// <summary>The real component of this complex number.</summary>
        public float r;
        /// <summary>The imaginary component of this complex number.</summary>
        public float i;

        public complex(float real, float imaginary) => (this.r, this.i) = (real, imaginary);

        public static complex operator +(complex a, complex b) => new complex(a.r + b.r, a.i + b.i);
        public static complex operator -(complex a, complex b) => new complex(a.r - b.r, a.i - b.i);
        public static complex operator *(complex a, complex b) => new complex(a.r * b.r - a.i * b.i, a.r * b.i + a.i * b.r);

        public static implicit operator complex(float f) => new complex(f, 0f);
    }

}