#include <iostream>   // std::cout, etc.
#include <cstddef>    // std::size_t

std::size_t descartar_con_indices(std::size_t n, int a[], std::size_t a_size) {

  if (a_size < n) return a_size;
  for (std:: size_t b{0};b< a_size;b++){
  	if (b< a_size-n) a[b] = a [b+n];
  	else a[b] = 0;
  }
}

std::size_t descartar_con_punteros(std::size_t n, int* begin, int* end) {

  if ((end-begin)<n) return (end-begin);
  else {
  	for (std::size_t b{0};b< (end-begin);++b){
  		if (b< ((end-begin)-n)) *(begin+b) = *(begin+(b+n));
  		else *(begin + b)= 0;
	    }
	return ((end-begin)-n);
  }
}

// NO TOCAR NADA A PARTIR DE ESTA LÍNEA ************************************/
template <typename T>
void show(T* begin, T* end, std::size_t t) {
  std::cout << '{';
  for ( ; begin != end; ++begin)
    std::cout << '\'' << *begin << '\''<< (begin != end - 1 ? "," : "");
  std::cout << "} remain " << t << " elements" << std::endl;
}

int main() {
  const std::size_t num_tests {5};
  const std::size_t t_size {7};
  const int seed[t_size]{1,4,5,3,2,6,7};
  const std::size_t ns[num_tests]{3, 6, t_size, 0, 1};
  int xs[num_tests][t_size];
  int ys[num_tests][t_size];
  for (std::size_t i {0}; i < num_tests; ++i)
    for (std::size_t j {0}; j < t_size; ++j) {
      xs[i][j] = seed[j];
      ys[i][j] = seed[j];
    }

  std::size_t t;

  std::cout << "--------------------" << std::endl;
  show(xs[0], xs[0] + t_size, t_size);
  std::cout << "--------------------" << std::endl;

  for (std::size_t i {0}; i < num_tests; ++i) {
    std::cout << "descartar_con_indices " << ns[i] << std::endl;
    t = descartar_con_indices(ns[i], xs[i], t_size);
    show(xs[i], xs[i] + t_size, t);
  }
  std::cout << "--------------------" << std::endl;
  for (std::size_t i {0}; i < num_tests; ++i) {
    std::cout << "descartar_con_punteros " << ns[i] << std::endl;
    t = descartar_con_punteros(ns[i], &ys[i][0], &ys[i][t_size]);
    show(ys[i], ys[i] + t_size, t);
  }
  std::cin.get();
  return 0;
}

/* LA SALIDA POR PANTALLA DEBE SER:

--------------------
{'1','4','5','3','2','6','7'} remain 7 elements
--------------------
descartar_con_indices 3
{'3','2','6','7','0','0','0'} remain 4 elements
descartar_con_indices 6
{'7','0','0','0','0','0','0'} remain 1 elements
descartar_con_indices 7
{'0','0','0','0','0','0','0'} remain 0 elements
descartar_con_indices 0
{'1','4','5','3','2','6','7'} remain 7 elements
descartar_con_indices 1
{'4','5','3','2','6','7','0'} remain 6 elements
--------------------
descartar_con_punteros 3
{'3','2','6','7','0','0','0'} remain 4 elements
descartar_con_punteros 6
{'7','0','0','0','0','0','0'} remain 1 elements
descartar_con_punteros 7
{'0','0','0','0','0','0','0'} remain 0 elements
descartar_con_punteros 0
{'1','4','5','3','2','6','7'} remain 7 elements
descartar_con_punteros 1
{'4','5','3','2','6','7','0'} remain 6 elements

*/
