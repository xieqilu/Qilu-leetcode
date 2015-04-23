///////////////////////////////////////////////////////////////////////
// VehicleDesign.cs - This file contains multiple classes to         //
// implement an object-oriented design for vehicle model             //
// ver 1.0                                                           //
// Language:    C#, Xamarin Studio 5.4,.Net Framework 4.0            //
// Platform:    Mac OSX 10.9.5, Macbook Pro Md101                    //
// Application: Code challenge for application to Xignite            //
// Author:      Qilu Xie, Syracuse University                        //
//              (315) 436-2925, qxie@syr.edu                         //
///////////////////////////////////////////////////////////////////////

/*
* Module Operations:
* ------------------
* This module defines the following class:
* Vehicle  - an abstract class defining the general properties and methods
*            for all vehicles
* IEngine - an interface defining the general methods of all engines
* NormalEngine - a class derived from IEngine defining unique properties
* 				and methods for normal engines
* ElectricEngine - a class derived from IEngine defining unique properties
*				and methods for electric engines
* HybridEngine - a class derived from IEngine defining unique properties 
*				and methods for hybrid engines
* MotorEngine - a class derived from IEngine defining unique properties 
*				and methods for motorcycle engines
* Car - a class derived from Vehicle defining unique properties and methods
*		for cars
* Bus - a class derived from Vehicle defining unique properties and methods
*		for buses
* EmergencyCar - a class derived from Vehicle defining unique properties and
*				 methods for emergency cars
* Truck - a class derived from Vehicle defining unique properties and methods 
*         for trucks
* MotoCycle - a class derived from Vehicle defining unique properties and 
* 			  methods for motocycles
* PoliceCar - a class derived from Car defining unique properties and methods
*			  for police cars
* SchoolBus - a class derived from Bus defining unique properties and methods
* 			  for school buses
* PoliceMotor - a class derived from MotorCycle defining unique properties and 
*				methods for police motorcycles
*/
/* Required Files:
*   Vehicle.cs
*   
*   
* Maintenance History:
* --------------------
* ver 1.0 : 28 Sep 2014
* - first release
*/





using System;

namespace VehicleTest
{

	//////////////////////////////////////////////////////////////////
	//////////Define the high-level class for general vehicles

	public abstract class Vehicle   
	{
		public bool isMovingBack { get; set;}
		public bool isLocked { get; set;}
		public int wheelNumber { get; set;}
		public string make { get; private set;}
		public string color { get; set;}
		public string model { get; private set;}
		public int year { get; private set;}
		public string vinNumber { get; private set;}
		public string owner { get; set;}
		public int speed { get; set;}
		public string gearLevel { get; set;}
		public IEngine engine { get; set;}  //each vehicle must contains an engine

		protected Vehicle (string make, string model, int year, 
			string color, string vinNumber, string owner,IEngine engine)
		{
			this.make = make;
			this.model = model;
			this.year = year;
			this.vinNumber = vinNumber;
			this.owner = owner;
			this.speed = 0; 
			this.color = color;
			this.isLocked = true;
			this.isMovingBack = false;
			this.gearLevel = "P";
			this.engine = engine;
		}


		public virtual void Accelerate (int increment) { }  //provide some basic methods for all vehicles
		public virtual void Decelerate (int decrement) { }
		public virtual void Reverse (int speed) { }
		public virtual void TurnLeft () { }
		public virtual void TurnRight () { }
		public virtual bool Locking () { return true;}
		public virtual bool Unlocking () { return true;}
		public virtual void Honk () { }
		public virtual void TurnOnLight () { }
		public virtual void TurnOffLight () { }
		public virtual void ChangeGear (string currentGear) { }

	}

	/////////////////////////////////////////////////////////////////////////////
	//////////Define the Interface for general engines,provide basic methods

	public interface IEngine 
	{
		void GoFaster (); //provide methods that concerete engine class need to implement
		void GoSlower ();
		void FillFuelAndCharge ();
	}

	///////////////////////////////////////////////////////////////////////
	//////////Define the class for normal engine

	public class NormalEngine : IEngine
	{
		public double fuelLevel { get; set;}
		public NormalEngine(double fuelLevel)
		{
			this.fuelLevel = fuelLevel;
		}

		void IEngine.GoFaster () { } // implement methods of interface
		void IEngine.GoSlower () { }
		void IEngine.FillFuelAndCharge () { }
	}

	///////////////////////////////////////////////////////////////////////
	//////////Define the class for eletric engine

	public class ElectricEngine : IEngine
	{
		public double batteryLevel { get; set;}
		public ElectricEngine(double batteryLevel)
		{
			this.batteryLevel = batteryLevel;
		}

		void IEngine.GoFaster () { } //implement methods of interface
		void IEngine.GoSlower () { }
		void IEngine.FillFuelAndCharge () { }
	}

	///////////////////////////////////////////////////////////////////////
	//////////Define the class for hybrid engine

	public class HybridEngine : IEngine
	{
		public double fuelLevel { get; set;} //hybrid engine has both fuel and battery levels
		public double batteryLevel { get; set;}
		public HybridEngine(double fuelLevel, double batteryLevel)
		{
			this.batteryLevel = batteryLevel;
			this.fuelLevel = fuelLevel;
		}

		void IEngine.GoFaster () { } //implement methods of interface
		void IEngine.GoSlower () { }
		void IEngine.FillFuelAndCharge () { }
	}

	///////////////////////////////////////////////////////////////////////
	//////////Define the class for motorcycle engine

	public class MotorEngine : IEngine
	{
		public double fuelLevel { get; set;} 
		public MotorEngine (double fuelLevel)
		{
			this.fuelLevel = fuelLevel;
		}

		void IEngine.GoFaster () { } //methods implementation of motorcycle engines
		void IEngine.GoSlower () { } //are quite different from car engines
		void IEngine.FillFuelAndCharge () { }
	}

	/////////////////////////////////////////////////////////////////////////////
	//////////Define the class for normal cars(including compact,suv, etc.)

	public class Car : Vehicle
	{
		public string stereoType {get; set;} //car type: SUV, Compact, sedan, etc.
		public Car (string make, string model, int year, string stereoType,
			string color, string vinNumber, string owner,IEngine engine): 
			base(make,model,year,color,vinNumber,owner,engine)
		{
			this.wheelNumber = 4; //usually car has four wheels
			this.stereoType = stereoType;
		}

		public void RollDownWindow () { } //motorcycle cannot have these three methods
		public void RollUpWindow () { }   //so we do not define them in Vehicle class
		public void UseSlider () { }
	}
		
	/////////////////////////////////////////////
	//////////Define the class for buses

	public class Bus : Vehicle
	{
		public bool hasSecondFloor { get; set;} //indicate if the bus have a second floor or not
		public int passengerCapacity { get; set;} //max number of passengers
		public Bus (int wheelNumber, string make, string model, int year, bool hasSecondFloor, int passengerCapacity,
			string color, string vinNumber, string owner,IEngine engine): 
			base(make,model,year,color,vinNumber,owner,engine)
		{
			this.hasSecondFloor = hasSecondFloor;
			this.wheelNumber = wheelNumber; // bus can have different numbers of wheels
			this.passengerCapacity = passengerCapacity;
		}

		public void RollDownWindow () { }
		public void RollUpWindow () { }
		public void UseSlider () { }
		public virtual void ArriveToStation () { } //unique methods for buses
		public virtual void DepartFromStation () { }


	}
		
	//////////////////////////////////////////////////////////////////
	//////////Define the class for emergency cars

	public class EmergencyCar : Vehicle
	{
		public string department { get; set;}
		public EmergencyCar (int wheelNumber,string make, string model, int year, string department,
			string color, string vinNumber, string owner,IEngine engine): 
			base(make,model,year, color,vinNumber,owner,engine)
		{
			this.department = department;
			this.wheelNumber = wheelNumber;
		}

		public override void Accelerate (int increment) { } //emergency cars might run differentlly
		public override void Decelerate (int decrement) { } //from other cars
		public override void Reverse (int speed) { }
		public override void TurnLeft () { }
		public override void TurnRight () { }
		public void RollDownWindow () { }
		public void RollUpWindow () { }
		public void UseSlider () { }
		public void PerformTreatment () { } //unique methods for emergency cars
	}

	///////////////////////////////////////////////////////////////////////
	//////////Define the class for trucks

	public class Truck : Vehicle
	{
		public int loadingCapacity { get; set;}
		public Truck (int wheelNumber, string make, string model, int year, int loadingCapcacity,
			string color, string vinNumber, string owner,IEngine engine): 
			base(make,model,year,color,vinNumber,owner,engine)
		{
			this.wheelNumber = wheelNumber;
			this.loadingCapacity = loadingCapacity;
		}
			
		public void RollDownWindow () { }
		public void RollUpWindow () { }
		public void UseSlider () { }
		public void LoadStaff() { }  //unique methods for trucks
		public void UnloadStaff () { }

	}
		
	///////////////////////////////////////////////////////////////////////
	//////////Define the class for motorcycles

	public class MotorCycle : Vehicle
	{
		public MotorCycle (string make, string model, int year, 
			string color, string vinNumber, string owner,IEngine engine):
			base(make,model,year,color,vinNumber,owner,engine)
		{
			this.wheelNumber = 2; //motorcycle has two wheels
		}

		public override void Accelerate (int increment) { } // motorcycle runs differently from other vehicles
		public override void Decelerate (int decrement) { }
		public override void Reverse (int speed) { }
		public override void TurnLeft () { }
		public override void TurnRight () { }
		public override void ChangeGear (string currentGear) { } //motorcycle change gears differentlly from others
	}


	///////////////////////////////////////////////////////////////////////
	//////////Define the class for police cars, derived from Car

	public class PoliceCar : Car
	{
		public string policeDepartment { get; set;}
		public PoliceCar (string make, string model, int year, string stereoType, string policeDepartment,
			string color, string vinNumber, string owner,IEngine engine): 
			base(make,model,year,stereoType, color,vinNumber,owner,engine)
		{
			this.policeDepartment = policeDepartment;
		}
			
		public override void Accelerate (int increment) { } //police cars might run differentlly from 
		public override void Decelerate (int decrement) { } //other cars
		public override void Reverse (int speed) { }
		public override void TurnLeft () { }
		public override void TurnRight () { }
		public void StartFlashLight () { } //unique methods for police cars
		public void StopFlashLight () { }
		public void UserLoudSpeaker () { }

	}

	///////////////////////////////////////////////////////////////////////
	//////////Define the class for school buses, derived from Bus

	public class SchoolBus : Bus
	{
		public SchoolBus (int wheelNumber, string make, string model, int year, bool hasSecondFloor, int passengerCapacity,
			string color, string vinNumber, string owner,IEngine engine): 
			base(wheelNumber,make,model,year,hasSecondFloor,passengerCapacity,color,vinNumber,owner,engine)
		{
		}

		public override void ArriveToStation () { }
		public override void DepartFromStation () { }
		public void FlashRedLight () { } //unique methods for school buses
		public void UseStopSign () { }
		public void CeaseStopSign () { }
	}

	/////////////////////////////////////////////////////////////////////////////////
	//////////Define the class for police motorcycle, derived from MotorCycle

	public class PoliceMotor : MotorCycle
	{
		public string policeDepartment { get; set;}
		public PoliceMotor (string make, string model, int year, string policeDepartment,
			string color, string vinNumber, string owner,IEngine engine): 
			base(make,model,year,color,vinNumber,owner,engine)
		{
			this.policeDepartment = policeDepartment;
		}

		public override void Accelerate (int increment) { } //police motorcycles might run differentlly from 
		public override void Decelerate (int decrement) { } //other motorcycles
		public override void Reverse (int speed) { }
		public override void TurnLeft () { }
		public override void TurnRight () { }
		public void StartFlashLight () { } //unique methods for police motorcycle
		public void StopFlashLight () { }
		public void UserLoudSpeaker () { }
	}


	class VehicleProgram  //test stub
	{
		public static void Main (string[] args)
		{
			//shows how to instantiate different engines.
			//since all vehicles and cars will need an engine,
			//it's better to instantiate engines firstly

			NormalEngine normalengine = new NormalEngine (0.25);   
			ElectricEngine electricengine = new ElectricEngine (0.45);
			HybridEngine hybridengine = new HybridEngine (0.65,0.55);  //hybrid engine have two properties 
			MotorEngine motorengine = new MotorEngine (0.10);

			//shows how to instantiate different kinds of vehicles

			Car mycar = new Car ("Toyota", "Rav4", 2008, "compact", "Red", "xxxx", "Qilu",normalengine);
			Bus mybus = new Bus (10, "Toyota", "Rav4", 2008, true, 55, "Red", "xxxx", "Qilu", normalengine );
			EmergencyCar emergencycar = new EmergencyCar (10,"Toyota","Rav4",2008,"hospital","Red","xxxx","Qilu",normalengine);
			Truck mytruck = new Truck ( 8, "Toyota", "Rav4", 2008, 7000, "Red", "xxxx", "Qilu",hybridengine);
			MotorCycle motor = new MotorCycle ("Toyota", "Rav4", 2008, "Red", "xxxx", "Qilu",motorengine);
			PoliceCar policecar = new PoliceCar ("Ford", "Mustang", 2012, "SUV", "LAPD", "Black", "xxxxxxx", "Matt",hybridengine);
			SchoolBus schoolbus = new SchoolBus (10, "Toyota", "Rav4", 2008, false, 40, "Red", "xxxx", "Qilu" ,electricengine);
			PoliceMotor policemotor = new PoliceMotor ("Toyota", "Rav4", 2008, "LAPD", "Red", "xxxx", "Qilu",motorengine);

		}
		
	}

}
