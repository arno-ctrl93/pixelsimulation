
    public class Direction
    { 
        /* THE CLASS DIRECTION IS COMPOSED BY
        * float x,y = define the next position of agents
        */
        public float x;
        public float y;
	
        // CONSTRUCTOR 
        public Direction(float x,float y) {
            this.x = x;
            this.y = y;
        }
        
        // GETTER AND SETTER OF THE CLASS DIRECTION

        public float getX() {
            return x;
        }

        public void setX(float x) {
            this.x = x;
        }

        public float getY() {
            return y;
        }

        public void setY(float y) {
            this.y = y;
        }
    }