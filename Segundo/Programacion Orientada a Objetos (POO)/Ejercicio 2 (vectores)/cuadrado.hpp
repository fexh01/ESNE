#ifndef CUADRADO_H
#define CUADRADO_H

#include <cstddef> // std::size_t
#include <string>

class Cuadrado {
public:
  Cuadrado()                           = delete;
  Cuadrado(const Cuadrado&)            = default;
  Cuadrado(Cuadrado&&)                 = default;
  Cuadrado& operator=(const Cuadrado&) = default;
  Cuadrado& operator=(Cuadrado&&)      = default;
  ~Cuadrado()                          = default;

  Cuadrado(std::string,std::size_t);
  std::string get_nombre() const;
  std::size_t get_perimetro() const;
  double area() const ;

private:
  std::string nombre;
  std::size_t perimetro;
  std::size_t lado;
};

#endif
