$( document ).ready(function() 
{
	function supports_html5_storage() 
	{
	  try 
	  {
	    return 'localStorage' in window && window['localStorage'] !== null;
	  } 
	  catch (e) 
	  {
	    return false;
	  }
	}

	var SimpleListModel = function(items) 
	{
	    this.items = ko.observableArray(items);
	    this.itemToAdd = ko.observable("");
	    this.addItem = function() 
	    {
	        if (this.itemToAdd() != "") 
	        {
	        		// Adds the item. Writing to the "items" observableArray causes any associated UI to update.
	            this.items.push(this.itemToAdd()); 
	            
	            localStorage.setItem("item", this.itemToAdd());
	            
	            // Clears the text box, because it's bound to the "itemToAdd" observable
	            this.itemToAdd(""); 
	        }
	    }.bind(this);  // Ensure that "this" is always this view model
	};
	
	ko.applyBindings(new SimpleListModel( ["Alpha", "Beta", "Gamma"] ));
});