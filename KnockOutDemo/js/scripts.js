// This is a simple *viewmodel* - JavaScript that defines the data and behavior of your UI

$(function() 
{
	function AppViewModel() 
	{
	    this.firstName = ko.observable("Dan");
	    this.lastName = ko.observable("Schwie");
	    
	    this.fullName = ko.computed(function() 
	    {
		    return this.firstName() + " " + this.lastName();    
			}, this);
			
			this.capitalizeLastName = function()
			{
				var currentVal = this.lastName();
				this.lastName(currentVal.toUpperCase());
			};
	}
	
	function SeatReservation(name, initialMeal)
	{
		var self = this;
		self.name = name;
		self.meal = ko.observable(initialMeal);
	}
	
	function ReservationsViewModel()
	{
		var self = this;
		
		self.availableMeals = [
			{ mealName: "Standard (sandwich)", price: 0 },
			{ mealName: "Premium (steak)", price: 24.95 },
			{ mealName: "Ultimate (lobster)", price: 34.95 }
		];
		
		self.seats = ko.observableArray([
			new SeatReservation("Steve", self.availableMeals[0]),
			new SeatReservation("Joe", self.availableMeals[1])
		]);
		
		self.addSeat = function()
		{
			self.seats.push(new SeatReservation("", self.availableMeals[0]));
		}
		
		self.removeSeat = function(seat)
		{	
			self.seats.remove(seat);
		}
		
		self.totalSurcharge = ko.computed(function()
		{	
			var total = 0;
			
			for(var i = 0; i < self.seats().length; i++)
			{
				total += self.seats()[i].meal().price;
			}
			
			return total;
		});
	}

	// Activates knockout.js
	ko.applyBindings(new ReservationsViewModel());
	ko.applyBindings(new AppViewModel());
});