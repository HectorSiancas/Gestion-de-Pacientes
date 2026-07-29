package com.utp.sistemas.services;

import com.utp.sistemas.entities.Menu;
import com.utp.sistemas.repositories.MenuRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.util.List;
import java.util.Optional;

@Service
public class MenuService {

    @Autowired
    private MenuRepository menuRepository;

    public Menu createMenu(Menu menu) {
        return menuRepository.save(menu);
    }

    public List<Menu> getAllMenus() {
        return menuRepository.findAll();
    }

    public Optional<Menu> getMenuById(Integer id) {
        return menuRepository.findById(id);
    }

    public Menu updateMenu(Integer id, Menu menuDetails) {
        Optional<Menu> menu = menuRepository.findById(id);
        if (menu.isPresent()) {
            Menu updatedMenu = menu.get();
            updatedMenu.setNombre(menuDetails.getNombre());
            updatedMenu.setIsSubmenu(menuDetails.getIsSubmenu());
            updatedMenu.setUrl(menuDetails.getUrl());
            updatedMenu.setMenuParent(menuDetails.getMenuParent());
            updatedMenu.setEstado(menuDetails.getEstado());
            updatedMenu.setShow(menuDetails.getShow());
            updatedMenu.setOrden(menuDetails.getOrden());
            return menuRepository.save(updatedMenu);
        }
        return null;
    }

    public void deleteMenu(Integer id) {
        Optional<Menu> menu = menuRepository.findById(id);
        menu.ifPresent(m -> menuRepository.delete(m));
    }
}