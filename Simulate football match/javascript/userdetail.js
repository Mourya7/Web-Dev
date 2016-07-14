function buildForm()
{   //create form and add elements
    var formEle = document.createElement('form'); 
	formEle.setAttribute("action", "user.html");        
	formEle.setAttribute("method", "get");  
    formEle.setAttribute("id","userForm");
	document.getElementById("submitForm").appendChild(formEle);

    var title = document.createElement('h3'); // form title
    title.appendChild(document.createTextNode("Fill in the details please!"));
	formEle.appendChild(title);
    
    var breakEle = document.createElement('br');
	formEle.appendChild(breakEle);

    var nameEle = document.createElement('input'); 
    nameEle.setAttribute("id", "formUserName");
    
    if(localStorage)
    {
       if(localStorage.getItem('username'))
        {
            nameEle.setAttribute("value", localStorage.getItem('username'));   
        } 
    } 
    else
    {
         if(GetCookie('username'))
        {
            nameEle.setAttribute("value", GetCookie('username'));   
        } 
    }
	formEle.appendChild(nameEle);
    
    var nLabel = document.createElement('label');       
    nLabel.setAttribute("type", "text");
   
    var text = document.createTextNode("Name ");
    nLabel.appendChild(text);
    document.getElementsByTagName("form")[0].insertBefore(nLabel,document.getElementsByTagName("form")[0].childNodes[2]);
	
	formEle.appendChild(breakEle);
	formEle.appendChild(breakEle);

    var sEle = document.createElement('input'); 
    sEle.setAttribute("type", "submit");
	sEle.setAttribute("value", "Submit");
	formEle.appendChild(sEle);
    
    document.getElementById("userForm").onsubmit =function(){ 
     return formValidate(); };
}

function formValidate()
{
        var name = document.getElementById("formUserName").value;
        if (name == null || name == "" || name == " " ) 
        {
              window.alert("Come on! stop playing around, enter your name");
            {
                return false;
            }
        }
    localStorageData(name,userTeam);
               
}

function localStorageData(name,userTeam)
{
				if(localStorage)
                {
                    if(localStorage.getItem('username')==name)  //if user already visited, increment his matches played
                    {
                        localStorage.setItem('teamname',userTeam.name);
                        localStorage.setItem('teamscore',userTeam.score);
                        localStorage.setItem('played',parseInt(localStorage.getItem('played'))+1);
                    }
                    else
                    {                                           //if first time, set matches played to one
                        localStorage.setItem('username',name);
                        localStorage.setItem('teamname',userTeam.name);
                        localStorage.setItem('teamscore',userTeam.score);
                        localStorage.setItem('played',"1");
                    }
				    
				}
                else
                {
                    if(GetCookie('username')==name)
                    {
                        SetCookie('teamname',userTeam.name);
                        SetCookie('teamscore',userTeam.score);
                        SetCookie('played',parseInt(GetCookie('played'))+1);
                    }
                    else
                    {
                        SetCookie('username',name);
                        SetCookie('teamname',userTeam.name);
                        SetCookie('teamscore',userTeam.score);
                        SetCookie('played',1);
                    }
                       
                }
}
