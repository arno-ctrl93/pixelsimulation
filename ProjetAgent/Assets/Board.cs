public class Board {
    public int sizex;
    public int sizey;
	
    public Board(int x,int y) {
        this.sizex = x;
        this.sizey = y;
    }
	
    public void ChecktheCoord(Agent a) {
        if (a.posx >=sizex)
        {
            a.direction.x = -a.direction.x;
        }
        if (a.posy>=sizey)
        {
            a.direction.y = -a.direction.y;
        }
        if (a.posy<=0)
        {
            a.direction.y = -a.direction.y;
        }
        if (a.posx<=0)
        {
            a.direction.x = -a.direction.x;
        }
    }
    
    
	
}