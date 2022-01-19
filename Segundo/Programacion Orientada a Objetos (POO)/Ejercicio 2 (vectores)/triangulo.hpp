#ifndef TRIANGULO_H
#define TRIANGULO_H

#include <cstddef> // std::size_t
#include <string>

class Triangulo {
public:
  Triangulo()                            = delete;
  Triangulo(const Triangulo&)            = default;
  Triangulo(Triangulo&&)                 = default;
  Triangulo& operator=(const Triangulo&) = default;
  Triangulo& operator=(Triangulo&&)      = default;
  ~Triangulo()                           = default;

  Triangulo(std::string,std::size_t, std::size_t, std::size_t);
  std::string get_nombre() const;
  std::size_t get_perimetro() const;
  double area() const;

private:
  std::string nombre;
  std::size_t perimetro;
  std::size_t lado[3];
};

#endif
