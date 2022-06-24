// Fill out your copyright notice in the Description page of Project Settings.

#pragma once

#include "CoreMinimal.h"
#include "GameFramework/Actor.h"
#include "PaperSpriteComponent.h"
#include "CellClass.generated.h"

UCLASS()
class CAVEAUTOMATA_API ACellClass : public AActor
{
	GENERATED_BODY()
	
public:	
	UPROPERTY(EditAnywhere, Category = "Sprite Component")
		class UPaperSpriteComponent* Sprite;

	UPROPERTY(EditAnywhere, Category = "Cell Info")
		FVector2D info;

	// Sets default values for this actor's properties
	ACellClass();

protected:
	// Called when the game starts or when spawned
	virtual void BeginPlay() override;

public:	
	// Called every frame
	virtual void Tick(float DeltaTime) override;

};
