
namespace Nums {

    /*
        (a + bi) * (x + yi)

        ax + ayi + bix - by


    */


    public struct complex {

        public static readonly complex identity = 1.0f;
        public static readonly complex i = new complex(0, 1.0f);


        public float real;
        public float imaginary;

        public complex(float real, float imaginary) => (this.real, this.imaginary) = (real, imaginary);

        public static complex operator +(complex a, complex b) => new complex(a.real + b.real, a.imaginary + b.imaginary);
        public static complex operator -(complex a, complex b) => new complex(a.real - b.real, a.imaginary - b.imaginary);
        public static complex operator *(complex a, complex b) => new complex(a.real * b.real - a.imaginary * b.imaginary, a.real * b.imaginary + a.imaginary * b.real);

        public static implicit operator complex(float f) => new complex(f, 0f);
    }

}