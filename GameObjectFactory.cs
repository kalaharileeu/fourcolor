/*
Using Distributed Factories
-Distributed Factories can make a generic object factory that will create types.
-Distributed factories allow: dynamically maintain the types of objects we want the factory to create, rather than hard code them into a
function.
-The factory contain std::map that maps a string (the type of our object) to a small
class called Creator whose only purpose is the creation of a specific object. We will
register a new type with the factory using a function that takes a string (the ID) and
a Creator class and adds them to the factory's map. Start with the
base class for all the Creator types. Create GameObjectFactory.h and declare this
class at the top of the file.
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace fourcolors
{
    abstract class BaseCreator
    {
        public abstract EnemyGadget createGameObject();
    }

    class GameObjectFactory
    {
        static GameObjectFactory instance;
        //Constructor in private section: singleton
        public static GameObjectFactory Instance
        {
            get
            {
                if (instance == null)
                    instance = new GameObjectFactory();
                return instance;
            }
        }
    }
}

//class GameObjectFactory//Used by Game.cpp
//{
//    public:
//         //Constructor in private section: singleton
//        static GameObjectFactory* Instance()
//        {
//            if(s_pInstance == 0)
//            {
//                s_pInstance = new GameObjectFactory();
//                return s_pInstance;
//            }
//            return s_pInstance;
//        }

////        virtual ~GameObjectFactory();
///**function takes: ID to associate the object type. A way to add types to the map.*/
//        bool registerType(std::string typeID, BaseCreator* pCreator)
//        {
//            std::map<std::string, BaseCreator*>::iterator it = m_creators.find(typeID);
//            // if the type is already registered, do nothing
//            if(it != m_creators.end())
//            {
//                delete pCreator;
//                return false;//The typs is already registered return false
//            }
//            /**Assign the type id and base Creator to the map variable*/
//            m_creators[typeID] = pCreator;//Assign it to the map
//            //std::cout << "GameObjectFactory register: " << typeID << std::endl;
//            return true;
//        }
///**Get the typeID from the map and create the object
//Called from the game states to create their GameObjects*/
//        GameObject* create(std::string typeID)
//        {
//            std::map<std::string, BaseCreator*>::iterator it = m_creators.find(typeID);

//            if(it == m_creators.end())
//            {
//                //std::cout << "could not find type: " << typeID << "\n";
//                return 0;//Could not find it return
//            }
//            //std::cout << "GameObjectFactory create: " << typeID << std::endl;
//            BaseCreator* pCreator = (*it).second;//de-referensing the map iterator it get map pair elements with first and second
//            return pCreator->createGameObject();
//        }

//    protected:

//    private:
//        GameObjectFactory(){} /**Constructor in private section: singleton*/
//        ~GameObjectFactory(){}

//        static GameObjectFactory* s_pInstance;//The instance of GameObjectFactory

//        /**map holds the important elements of our factory, the functions of the class essentially either add or remove from this map*/
//        std::map<std::string, BaseCreator*> m_creators;
//};
//typedef GameObjectFactory TheGameObjectFactory;//Singleton parameters
//#endif // GAMEOBJECTFACTORY_H
