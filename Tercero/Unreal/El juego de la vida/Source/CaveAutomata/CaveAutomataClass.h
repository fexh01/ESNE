// Fill out your copyright notice in the Description page of Project Settings.

#pragma once

#include "CoreMinimal.h"
#include "CellClass.h"
#include "GameFramework/Actor.h"
#include "CaveAutomataClass.generated.h"

UCLASS()
class CAVEAUTOMATA_API ACaveAutomataClass : public AActor
{
	GENERATED_BODY()
	
public:	

	// Prefab de una c�lula est�ndar.
//Se trata de un actor que lleva un componente PaperSprite
	UPROPERTY(Category = Spawning, EditAnywhere, BlueprintReadWrite)
		UClass* genericCellPrefab;

	// Ancho de la caverna
	UPROPERTY(Category = Spawning, EditAnywhere, BlueprintReadWrite)
		int width;

	// Alto de la caverna
	UPROPERTY(Category = Spawning, EditAnywhere, BlueprintReadWrite)
		int height;

	// Porcentaje de relleno de la caverna
	UPROPERTY(Category = Spawning, EditAnywhere, BlueprintReadWrite)
		int randomFillPercent;

	// Color para una c�lula void
	UPROPERTY(Category = Spawning, EditAnywhere, BlueprintReadWrite)
		FLinearColor voidColor;

	// Color para una c�lula live
	UPROPERTY(Category = Spawning, EditAnywhere, BlueprintReadWrite)
		FLinearColor liveColor;
	// Array que representa la caverna
	UPROPERTY(Category = Spawning, EditAnywhere, BlueprintReadWrite)
		TArray<int> cave;
	UPROPERTY(Category = Spawning, EditAnywhere, BlueprintReadWrite)
		bool started;
	UPROPERTY(Category = Spawning, EditAnywhere, BlueprintReadWrite)
		bool selecting;
	UPROPERTY(Category = Spawning, EditAnywhere, BlueprintReadWrite)
		int selected;
private:
	// // Array que representa la caverna
	// TArray<int> cave;

	//Estado de la caverna
	enum CaveState { Idle, Process };
	CaveState caveState;

	// N�mero m�ximo en la que se considera soledad
	const int lonely = 4;

	// N�mero de generaciones a la que se evolucionar� la poblaci�n inicial;
	const int numGenerationsEvolution = 5;

	// Lista de c�lulas. Son referencias a actores que llevan un sprite
	TArray<ACellClass*> cellList;

	//Referencia al player Controller para prop�sitos de intercepci�n de acciones de teclado
	APlayerController* controller;

public:
	// Sets default values for this actor's properties
	ACaveAutomataClass();

protected:
	// Called when the game starts or when spawned
	virtual void BeginPlay() override;

public:	
	// Called every frame
	virtual void Tick(float DeltaTime) override;

private:

	//Establece los par�metros iniciales de la caverna
	void SetupCave();

	// Genera la caverna
	void GenerateCave();

	//Hace que los sprites de los elemntos ACellClass de cellList 
	//adquieran el color correspondiente a su estado (void/live)
	void SetCaveState();

	// Rellena la caverna aleatoriamente
	void RandomFillCave();

	// Regla local para decidir si una c�lula sigue viva
	void AutomataLocalRule();

	// Obtiene el n�mero de c�lulas vecina vivas de una posici�n pasada como par�metro
	int GetNeighbour(int cell_x, int cell_y);

	//A�ade c�lulas est�ndar al array de c�lulas a partir del spawn de prefabs
	void FillCave();

	//Intercepta pulsaci�n tecla
	UFUNCTION()
		void GenerateNext();
	UFUNCTION()
		void Restart();
	UFUNCTION()
		void ClearCave();
	UFUNCTION()
		void Select();
	UFUNCTION()
		void Next();
	UFUNCTION()
		void Previous();
};
