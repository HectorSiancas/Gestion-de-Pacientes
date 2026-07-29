package com.utp.sistemas.entities;

import jakarta.persistence.*;
import lombok.AllArgsConstructor;
import lombok.Data;
import lombok.NoArgsConstructor;

@Entity
@Data
@NoArgsConstructor
@AllArgsConstructor
public class Menu {
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private Integer idMenu;

    @Column(length = 200)
    private String nombre;

    private Boolean isSubmenu;

    @Column(length = 200)
    private String url;

    @ManyToOne
    @JoinColumn(name = "idMenuParent")
    private Menu menuParent;

    private Boolean estado;

    private Boolean show;

    private Integer orden;
}
