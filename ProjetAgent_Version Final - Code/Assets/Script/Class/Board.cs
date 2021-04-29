public class Board {
    
    /* THE CLASS BOARD IS COMPOSED BY
     * int sizex, sizey = define the dimension of the board
     */
    public int sizex;
    public int sizey;
	
    // CONSTRUCTOR
    public Board(int x,int y) {
        this.sizex = x;
        this.sizey = y;
    }
	
    // FUNCTION USED TO CHECK IF AGENT IS IN THE BOARD OR NOT (SO CHANGE THE DIRECTION OF THE AGENT)
    public void ChecktheCoord(Agent a,float speed) {
        if (a.posx >=sizex)
        {
            a.direction.x = -speed;
        }
        if (a.posy>=sizey)
        {
            a.direction.y = -speed;
        }
        if (a.posy<=0)
        {
            a.direction.y = speed;
        }
        if (a.posx<=0)
        {
            a.direction.x = speed;
        }
    }
    
    
	
}