# CMakeList.txt: OpenGL_Learning 的 CMake 项目，在此处包括源代码并定义
# 项目特定的逻辑。
#
cmake_minimum_required (VERSION 3.20)
project (OpenGL_Learning)

set(SRC_LIST)
set(MAIN_FILE  "Code/advanced_opengl/normal_mapping.cpp") # 此处为入口文件也即main函数.cpp文件路径
set ( PRJ_LIBRARIES )
set ( PRJ_INCLUDE_DIRS )
set ( IMGUI_HOME "includes/imgui")
# # 头文件搜索路径添加，这样就不需要相对项目路径寻址了

list(APPEND PRJ_INCLUDE_DIRS "includes")
list(APPEND PRJ_INCLUDE_DIRS "${IMGUI_HOME}")

file(GLOB include_files "includes/*.h")
list(APPEND SRC_LIST ${include_files})
list(APPEND SRC_LIST "includes/stb_image.cpp")

file ( GLOB imgui_header_files "${IMGUI_HOME}/*.h" )
list(APPEND SRC_LIST ${imgui_header_files})
file ( GLOB imgui_src_files "${IMGUI_HOME}/*.cpp" )
list(APPEND SRC_LIST ${imgui_src_files})


# 预先使用vcpkg安装以下库，然后直接通过find_package和target_link_libraries就可以简单使用了
find_package(glfw3 CONFIG REQUIRED)
find_package(glad CONFIG REQUIRED)
find_package(glm CONFIG REQUIRED)
find_package(assimp CONFIG REQUIRED)
find_package ( OpenGL REQUIRED )
# 将指定添加到头文件搜索路径下
add_executable (${PROJECT_NAME} ${SRC_LIST} ${MAIN_FILE} )


# 将头文件搜索路径添加
target_include_directories ( ${PROJECT_NAME}
	PRIVATE 
        ${PRJ_INCLUDE_DIRS}
)
# 链接库
target_link_libraries ( ${PROJECT_NAME} 
    PRIVATE 
        ${PRJ_LIBRARIES}
)

# vcpkg 第三方库链接
target_link_libraries(${PROJECT_NAME} PRIVATE glfw)
target_link_libraries(${PROJECT_NAME} PRIVATE glad::glad)
target_link_libraries(${PROJECT_NAME} PRIVATE glm::glm)
target_link_libraries(${PROJECT_NAME} PRIVATE assimp::assimp)