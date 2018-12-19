using System.Collections.Generic;
using System.Drawing;

namespace TetrisDb
{
    public abstract class Tetromino
    {
        protected List<int[,]> BlockPositions;
        private int Rotation;
        public Point Position { get; protected set; }

        public int[,] Block => BlockPositions[Rotation];

        public void Rotate()
        {
            Rotation = (Rotation + 1) % 4;
        }
    }

    public class I : Tetromino
    {
        public I()
        {
            Position = new Point(5, 21);

            BlockPositions = new List<int[,]>
            {
                new[,]
                {
                    {0, 0, 0, 0},
                    {1, 1, 1, 1},
                    {0, 0, 0, 0},
                    {0, 0, 0, 0}
                },
                new[,]
                {
                    {0, 1, 0, 0},
                    {0, 1, 0, 0},
                    {0, 1, 0, 0},
                    {0, 1, 0, 0}
                },
                new[,]
                {
                    {0, 0, 0, 0},
                    {1, 1, 1, 1},
                    {0, 0, 0, 0},
                    {0, 0, 0, 0}
                },
                new[,]
                {
                    {0, 1, 0, 0},
                    {0, 1, 0, 0},
                    {0, 1, 0, 0},
                    {0, 1, 0, 0}
                }
            };
        }
    }
    public class J : Tetromino
    {
        public J()
        {
            Position = new Point(5, 21);

            BlockPositions = new List<int[,]>
            {
                new[,]
                {
                    {0, 0, 0, 0},
                    {1, 0, 0, 0},
                    {1, 1, 1, 0},
                    {0, 0, 0, 0}
                },
                new[,]
                {
                    {0, 0, 0, 0},
                    {0, 1, 1, 0},
                    {0, 1, 0, 0},
                    {0, 1, 0, 0}
                },
                new[,]
                {
                    {0, 0, 0, 0},
                    {0, 0, 0, 0},
                    {1, 1, 1, 0},
                    {0, 0, 1, 0}
                },
                new[,]
                {
                    {0, 0, 0, 0},
                    {0, 1, 0, 0},
                    {0, 1, 0, 0},
                    {1, 1, 0, 0}
                }
            };
        }
    }
    public class L : Tetromino
    {
        public L()
        {
            Position = new Point(5, 21);

            BlockPositions = new List<int[,]>
            {
                new[,]
                {
                    {0, 0, 0, 0},
                    {0, 0, 1, 0},
                    {1, 1, 1, 0},
                    {0, 0, 0, 0}
                },
                new[,]
                {
                    {0, 0, 0, 0},
                    {0, 1, 0, 0},
                    {0, 1, 0, 0},
                    {0, 1, 1, 0}
                },
                new[,]
                {
                    {0, 0, 0, 0},
                    {0, 0, 0, 0},
                    {1, 1, 1, 0},
                    {1, 0, 0, 0}
                },
                new[,]
                {
                    {0, 0, 0, 0},
                    {1, 1, 0, 0},
                    {0, 1, 0, 0},
                    {0, 1, 0, 0}
                }
            };
        }
    }
    public class O : Tetromino
    {
        public O()
        {
            Position = new Point(5, 21);

            BlockPositions = new List<int[,]>
            {
                new[,]
                {
                    {0, 0, 0, 0},
                    {0, 0, 0, 0},
                    {1, 1, 0, 0},
                    {1, 1, 0, 0}
                },
                new[,]
                {
                    {0, 0, 0, 0},
                    {0, 0, 0, 0},
                    {1, 1, 0, 0},
                    {1, 1, 0, 0}
                },
                new[,]
                {
                    {0, 0, 0, 0},
                    {0, 0, 0, 0},
                    {1, 1, 0, 0},
                    {1, 1, 0, 0}
                },
                new[,]
                {
                    {0, 0, 0, 0},
                    {0, 0, 0, 0},
                    {1, 1, 0, 0},
                    {1, 1, 0, 0}
                }
            };
        }
    }
    public class S : Tetromino
    {
        public S()
        {
            Position = new Point(5, 21);

            BlockPositions = new List<int[,]>
            {
                new[,]
                {
                    {0, 0, 0, 0},
                    {0, 1, 1, 0},
                    {1, 1, 0, 0},
                    {0, 0, 0, 0}
                },
                new[,]
                {
                    {0, 0, 0, 0},
                    {0, 1, 0, 0},
                    {0, 1, 1, 0},
                    {0, 0, 1, 0}
                },
                new[,]
                {
                    {0, 0, 0, 0},
                    {0, 0, 0, 0},
                    {0, 1, 1, 0},
                    {1, 1, 0, 0}
                },
                new[,]
                {
                    {0, 0, 0, 0},
                    {1, 0, 0, 0},
                    {1, 1, 0, 0},
                    {0, 1, 0, 0}
                }
            };
        }
    }
    public class T : Tetromino
    {
        public T()
        {
            Position = new Point(5, 21);

            BlockPositions = new List<int[,]>
            {
                new[,]
                {
                    {0, 0, 0, 0},
                    {0, 1, 0, 0},
                    {1, 1, 1, 0},
                    {0, 0, 0, 0}
                },
                new[,]
                {
                    {0, 0, 0, 0},
                    {0, 1, 0, 0},
                    {0, 1, 1, 0},
                    {0, 1, 0, 0}
                },
                new[,]
                {
                    {0, 0, 0, 0},
                    {0, 0, 0, 0},
                    {1, 1, 1, 0},
                    {0, 1, 0, 0}
                },
                new[,]
                {
                    {0, 0, 0, 0},
                    {0, 1, 0, 0},
                    {1, 1, 0, 0},
                    {0, 1, 0, 0}
                }
            };
        }
    }
    public class Z : Tetromino
    {
        public Z()
        {
            Position = new Point(5, 21);

            BlockPositions = new List<int[,]>
            {
                new[,]
                {
                    {0, 0, 0, 0},
                    {1, 1, 0, 0},
                    {0, 1, 1, 0},
                    {0, 0, 0, 0}
                },
                new[,]
                {
                    {0, 0, 0, 0},
                    {0, 0, 1, 0},
                    {0, 1, 1, 0},
                    {0, 1, 0, 0}
                },
                new[,]
                {
                    {0, 0, 0, 0},
                    {0, 0, 0, 0},
                    {1, 1, 0, 0},
                    {0, 1, 1, 0}
                },
                new[,]
                {
                    {0, 0, 0, 0},
                    {0, 1, 0, 0},
                    {1, 1, 0, 0},
                    {1, 0, 0, 0}
                }
            };
        }
    }

}
