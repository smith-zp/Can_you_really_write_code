using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaterAPI
{
    /// <summary>
    /// 最简单的代码逻辑
    /// </summary>
    public class Container : IContainer
    {
        private Container[] g;
        private int n;
        private double x;

        public Container()
        {
            g =new Container[1000];
            g[0] = this;
            n = 1;
            x = 0;
        }

        public double GetAmount()
        {
            return x;
        }
        /// <summary>
        /// 存在漏洞 只适合
        /// </summary>
        /// <param name="c"></param>
        public void ConnectTo(Container c)
        {
            double z = (x * n + c.x * c.n) / (n + c.n);

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < c.n; j++)
                {
                    g[i].g[n + j] = c.g[j];
                    c.g[j].g[c.n + i] = g[i];
                }
            }

            n +=c.n;

            for (int i = 0; i < n; i++)
            {
                g[i].n = n;
                g[i].x = z;
            }
        }

        public void AddWater(double amount)
        {
            double y = x / n;
            for (int i = 0; i < n; i++)
            {
                g[i].x = g[i].x + y;
            }
        }
    }

    public interface IContainer
    {
        /// <summary>
        /// 返回此容器中的当前水量
        /// </summary>
        /// <returns></returns>
        double GetAmount();

        /// <summary>
        /// 将此容器永久连接到另一个容器（other）。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="other"></param>
        void ConnectTo(Container other);
        /// <summary>
        /// 将一定量的水（amount）倒入此容器中。
        /// 此方法在所有直接或间接连接到该容器的容器间自动均分其中的水
        /// </summary>
        /// <param name="amount"></param>
        void AddWater(double amount);
    }
}
