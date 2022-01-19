#include <cstddef> // std::size_t
#include <cmath>   // std::sqrt
#include "triangulo.hpp"

Triangulo::Triangulo(std::string nombre,
                     std::size_t lado1, std::size_t lado2, std::size_t lado3)
  : nombre { nombre} , perimetro {lado1 + lado2 + lado3 }
{
  lado[0] = lado1;
  lado[1] = lado2;
  lado[2] = lado3;
}

std::size_t Triangulo::get_perimetro() const { return perimetro; }

std::string Triangulo::get_nombre() const { return nombre; }

double Triangulo::area() const {
  double p { static_cast<double>(lado[0] + lado[1] + lado[2]) / 2.0 };
  double r { std::sqrt(p*(p-lado[0])*(p-lado[1])*(p-lado[2])) };
  return static_cast<std::size_t>(r);
}
