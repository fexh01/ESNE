// Fill out your copyright notice in the Description page of Project Settings.


#include "CaveAutomataClass.h"
#include "PaperSpriteComponent.h"

// Sets default values
ACaveAutomataClass::ACaveAutomataClass()
{
 	// Set this actor to call Tick() every frame.  You can turn this off to improve performance if you don't need it.
	PrimaryActorTick.bCanEverTick = false;

}

// Called when the game starts or when spawned
void ACaveAutomataClass::BeginPlay()
{
	Super::BeginPlay();
	
	started = false;
	selecting = true;
	selected = -1;
	//Se obtiene el playerController
	controller = GEngine->GetFirstLocalPlayerController(GetWorld());
	//Permite que se reciba el input del jugador
	EnableInput(controller);
	//Establece un m�todo que ser� llamado al recibir los eventos del Action Mapping
	InputComponent->BindAction("SPACE", IE_Pressed, this, &ACaveAutomataClass::GenerateNext);
	InputComponent->BindAction("Restart", IE_Pressed, this, &ACaveAutomataClass::Restart);
	InputComponent->BindAction("NextSelection", IE_Pressed, this, &ACaveAutomataClass::Next);
	InputComponent->BindAction("PreviousSelection", IE_Pressed, this, &ACaveAutomataClass::Previous);
	InputComponent->BindAction("Select", IE_Pressed, this, &ACaveAutomataClass::Select);
	//Establece los par�metros iniciales de la caverna y spawnea los prefabs
	SetupCave();
	//Se genera la primera caverna
	ClearCave();
}

// Called every frame
void ACaveAutomataClass::Tick(float DeltaTime)
{
	Super::Tick(DeltaTime);

}

//Gestiona la intercepci�n de pulsaciones de teclado
void ACaveAutomataClass::GenerateNext()
{
	if (caveState == CaveState::Idle)
		GenerateCave();

}
void ACaveAutomataClass::Restart()
{
	started = false;
	selecting = true;
	selected = 0;
	ClearCave();
	cave[selected] = 1;
	SetCaveState();
}
void ACaveAutomataClass::Select()
{
	if(!started){
		if(selected == cave.Num() - 1){
			selected = 0;
		}
		else{
			selected++;
		}
		SetCaveState();
	}
}
void ACaveAutomataClass::Next()
{
	if(!started){
		if(selected >= 0){
			cave[selected] = 0;
		}
		if(selected == cave.Num() - 1){
			selected = 0;
		}
		else{
			selected++;
		}
		cave[selected] = 1;
		SetCaveState();
	}
}
void ACaveAutomataClass::Previous()
{
	if(!started){
		cave[selected] = 0;
		if(selected == 0){
			selected = cave.Num()-1;
		}
		else{
			selected--;
		}
		cave[selected] = 1;
		SetCaveState();
	}
}

//Establece los par�mtros iniciales de la caverna
//Llama a FiilCave para generar las c�lulas
void ACaveAutomataClass::SetupCave()
{
	//Dimensiona el array de la caverna con el n�mero de c�lulas
	cave.AddDefaulted(width * height);

	//A�ade c�lulas est�ndar al array de c�lulas
	FillCave();
}

// Genera la caverna
void ACaveAutomataClass::GenerateCave()
{
	caveState = CaveState::Process;

	//Genera una poblaci�n de c�lulas inicial
	if(!started){
		started = true;
	}
	AutomataLocalRule();
	//Colorea los sprites en pantalla seg�n la informaci�n de cave
	SetCaveState();
	caveState = CaveState::Idle;
}

void ACaveAutomataClass::ClearCave(){
	for (int i = 0; i < cave.Num(); i++)
	{
		cave[i] = 0;
	}
}

//Hace que los sprites de los elemntos ACellClass de cellList 
//adquieran el color correspondiente a su estado (void/live)
void ACaveAutomataClass::SetCaveState()
{
	for (int x = 0; x < width; x++)
	{
		for (int y = 0; y < height; y++)
		{
			//Acceso a los componentes sprite del actor
			TArray<UActorComponent*> sprites = cellList[(y * width) + x]->GetComponentsByClass(UPaperSpriteComponent::StaticClass());

			if (sprites.Num() > 0)
			{
				if (cave[(y * width) + x] == 1)
				{
					//Cambia el color del sprite
					((UPaperSpriteComponent*)sprites[0])->SetSpriteColor(liveColor);
				}
				else
				{
					//Cambia el color del sprite
					((UPaperSpriteComponent*)sprites[0])->SetSpriteColor(voidColor);
				}
			}
		}
	}
}

// Rellena la caverna aleatoriamente
void ACaveAutomataClass::RandomFillCave()
{

	FMath::RandInit(FPlatformTime::Seconds());

	for (int x = 0; x < width; x++)
	{
		for (int y = 0; y < height; y++)
		{
			//En los bordes del mapa siempre se generan c�lulas vivas 
			// if (x == 0 || x == width - 1 || y == 0 || y == height - 1)
			// {
			// 	cave[(y * width) + x] = 1;
			// }
			// else
			// {
			// 	if (FMath::FRandRange(0, 100) < randomFillPercent)
			// 	{
			// 		cave[(y * width) + x] = 1;
			// 	}
			// 	else
			// 	{
			// 		cave[(y * width) + x] = 0;
			// 	}
			// }
			if (FMath::FRandRange(0, 100) < randomFillPercent)
				{
					cave[(y * width) + x] = 1;
				}
				else
				{
					cave[(y * width) + x] = 0;
				}
		}
	}

}

// Regla local para decidir si una c�lula sigue viva
void ACaveAutomataClass::AutomataLocalRule()
{

	for (int x = 0; x < width; x++)
	{
		for (int y = 0; y < height; y++)
		{
			//Obtiene la poblaci�n de c�lulas vecinas
			int neighbourCellTiles = GetNeighbour(x, y);

			if(neighbourCellTiles == 3){
				cave[(y * width) + x] = 1;
			}

			neighbourCellTiles = 0;

		}
	}

	for (int x = 0; x < width; x++)
	{
		for (int y = 0; y < height; y++)
		{
			//Obtiene la poblaci�n de c�lulas vecinas
			int neighbourCellTiles = GetNeighbour(x, y);

			//Regla local, basada en el algoritmo:
			//https://github.com/SebLague/Procedural-Cave-Generation
			// if (neighbourCellTiles > lonely)
			// 	cave[(y * width) + x] = 1;
			// else if (neighbourCellTiles < lonely)
			// 	cave[(y * width) + x] = 0;

			if(neighbourCellTiles > 3 || neighbourCellTiles < 2){
				cave[(y * width) + x] = 0;
			}

			neighbourCellTiles = 0;

		}
	}

	

}

// Obtiene el n�mero de c�lulas vecina vivas de una posici�n pasada como par�metro
int ACaveAutomataClass::GetNeighbour(int cell_x, int cell_y)
{
	int cellCount = 0;

	//Recorre un grid de +-1 en sentido horizontal
	for (int neighbourX = cell_x - 1; neighbourX <= cell_x + 1; neighbourX++)
	{
		//Recorre un grid de +-1 en sentido vertical
		for (int neighbourY = cell_y - 1; neighbourY <= cell_y + 1; neighbourY++)
		{
			//Comprueba que no se salga de los l�mites del sujeto de prueba
			if (neighbourX >= 0 && neighbourX < width && neighbourY >= 0 && neighbourY < height)
			{
				if (neighbourX != cell_x || neighbourY != cell_y)
				{
					cellCount += cave[(neighbourY * width) + neighbourX];					
				}
			}
			// else
			// {
			// 	//cellCount++;
			// }
			
		}
	}

	return cellCount;
}

//A�ade c�lulas est�ndar al array de c�lulas a partir del spawn de prefabs
//Llamado desde SetupCave() se ejecuta una sola vez durante el transcurso de la partida.
void ACaveAutomataClass::FillCave()
{

	for (int x = 0; x < width; x++)
	{
		for (int y = 0; y < height; y++)
		{
			FVector* location = new FVector((-width * 100) / 2 + (x * 100) + 50, 0, (-height * 100) / 2 + (y * 100) + 50);
			FRotator* rotation = new FRotator(0, 0, 0);
			FActorSpawnParameters params;

			//Spawn actor
			ACellClass* cell = (ACellClass*)GetWorld()->SpawnActor(genericCellPrefab, location, rotation, params);
			//Accede a la variable p�blica info de la clase ACellClass
			cell->info = FVector2D(x, y);
			cellList.Add(cell);

		}
	}


}
