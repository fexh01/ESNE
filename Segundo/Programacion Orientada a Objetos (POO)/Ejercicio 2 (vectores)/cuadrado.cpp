#include <cstddef> // std::size_t
#include "cuadrado.hpp"

Cuadrado::Cuadrado(std::string nombre, std::size_t lado) :
  nombre {nombre}, perimetro { lado * 4}, lado { lado } {}

std::size_t Cuadrado::get_perimetro() const { return perimetro; }

std::string Cuadrado::get_nombre() const { return nombre; }

double Cuadrado::area() const {
  return lado * lado;
}
